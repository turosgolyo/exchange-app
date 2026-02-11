namespace Exchange.Services.Transaction;

public class ExchangeRateService(ApplicationDbContext dbContext) : IExchangeRateService
{

    public async Task<ErrorOr<ExchangeRateModel>> CreateAsync(ExchangeRateModel exchangeRate)
    {
        var newExchangeRate = exchangeRate.ToEntity();
        await dbContext.ExchangeRates.AddAsync(newExchangeRate);
        await dbContext.SaveChangesAsync();

        return new ExchangeRateModel(newExchangeRate);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.ExchangeRates.AsNoTracking()
                                                  .Where(x => x.Id == id)
                                                  .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<ExchangeRateModel>>> GetAllAsync() => await dbContext.ExchangeRates.Select(x => new ExchangeRateModel(x))
                                                                                                      .ToListAsync();

    public async Task<ErrorOr<ExchangeRateModel>> GetByIdAsync(int id)
    {
        var exchangeRate = await dbContext.ExchangeRates.FirstOrDefaultAsync(x => x.Id == id);

        if (exchangeRate is null)
        {
            return Error.NotFound(description: "Exchange rate not found!");
        }
        return new ExchangeRateModel(exchangeRate);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ExchangeRateModel exchangeRate)
    {
        var existing = await dbContext.ExchangeRates.AsNoTracking().FirstOrDefaultAsync(b => b.Id == exchangeRate.Id);
        if (existing is null)
        {
            return Error.NotFound();
        }

        var newEntity = exchangeRate.ToEntity();

        dbContext.ExchangeRates.Update(newEntity);
        await dbContext.SaveChangesAsync();
        return Result.Success;
    }
}