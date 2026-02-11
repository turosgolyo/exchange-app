namespace Exchange.Domain.Database.Entities;

public class TransactionEntity
{
    public int Id { get; set; }

    public TransactionType Type { get; set; }

    public TransactionCurrency FromCurrency { get; set; }

    public TransactionCurrency ToCurrency { get; set; }

    public double Amount { get; set; }

    public IdType IDType { get; set; }

    public string IDNumber { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public virtual UserEntity User { get; set; }

    [ForeignKey("ExchangeRate")]
    public int ExchangeRateId { get; set; }

    public virtual ExchangeRateEntity ExchangeRate { get; set; }
}

