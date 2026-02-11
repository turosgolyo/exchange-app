namespace Exchange.Services.Transaction;

public class TransactionService(ApplicationDbContext dbContext) : ITransactionService
{

    public async Task<ErrorOr<TransactionModel>> CreateAsync(TransactionModel transaction)
    {
        var newTransaction = transaction.ToEntity();

        await dbContext.Transactions.AddAsync(newTransaction);
        await dbContext.SaveChangesAsync();

        return new TransactionModel(newTransaction);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.Transactions.AsNoTracking()
                                                 .Where(x => x.Id == id)
                                                 .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<TransactionModel>>> GetAllAsync() => await dbContext.Transactions.Select(x => new TransactionModel(x))
                                                                                                    .ToListAsync();

    public async Task<ErrorOr<TransactionModel>> GetByIdAsync(int id)
    {
        var transaction = await dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);

        if (transaction is null)
        {
            return Error.NotFound(description: "Transaction not found!");
        }

        return new TransactionModel(transaction);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(TransactionModel transaction)
    {
        var existingTransaction = await dbContext.Transactions.FirstOrDefaultAsync(b => b.Id == transaction.Id);

        if (existingTransaction is null)
        {
            return Error.NotFound();
        }

        existingTransaction = transaction.ToEntity();

        dbContext.Transactions.Update(existingTransaction);
        await dbContext.SaveChangesAsync();

        return Result.Success;
    }
}