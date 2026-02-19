using Exchange.Domain.Models.Views;

namespace Exchange.Services.Transaction;

public class ExchangeRateService(ApplicationDbContext dbContext) : IExchangeRateService
{
    private const int ROW_COUNT = 20;
    public async Task<ErrorOr<ExchangeRateModel>> CreateAsync(ExchangeRateModel exchangeRate)
    {
        var newExchangeRate = exchangeRate.ToEntity();
        await dbContext.ExchangeRates.AddAsync(newExchangeRate);
        await dbContext.SaveChangesAsync();

        return new ExchangeRateModel(newExchangeRate);
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

    public async Task<ErrorOr<PaginationModel<ExchangeRateModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var exchangeRates = await dbContext.ExchangeRates.AsNoTracking()
                                         .Skip(page * ROW_COUNT)
                                         .Take(ROW_COUNT)
                                         .Select(x => new ExchangeRateModel(x))
                                         .ToListAsync();

        var paginationModel = new PaginationModel<ExchangeRateModel>
        {
            Items = exchangeRates,
            Count = await dbContext.ExchangeRates.CountAsync()
        };

        return paginationModel;
    }
}