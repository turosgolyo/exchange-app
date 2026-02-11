using ErrorOr;
using Exchange.Domain.Models;

namespace Exchange.Services.Transaction;

public interface ITransactionService
{
    Task<ErrorOr<List<TransactionModel>>> GetAllAsync();
    Task<ErrorOr<TransactionModel>> GetByIdAsync(int id);
    Task<ErrorOr<TransactionModel>> CreateAsync(TransactionModel transaction);
    Task<ErrorOr<Success>> UpdateAsync(TransactionModel transaction);
    Task<ErrorOr<Success>> DeleteAsync(int id);
}
