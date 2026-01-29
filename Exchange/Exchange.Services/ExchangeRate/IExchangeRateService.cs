using ErrorOr;
using Exchange.Domain.Models;

namespace Exchange.Services.ExchangeRate;

public interface IExchangeRateService
{
    Task<ErrorOr<List<ExchangeRateModel>>> GetAllAsync();
    Task<ErrorOr<ExchangeRateModel>> GetByIdAsync(int id);
    Task<ErrorOr<ExchangeRateModel>> CreateAsync(ExchangeRateModel exchangeRate);
    Task<ErrorOr<Success>> UpdateAsync(ExchangeRateModel exchangeRate);
    Task<ErrorOr<Success>> DeleteAsync(int id);
}
