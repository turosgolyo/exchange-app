namespace Exchange.Domain.Models;

public partial class TransactionModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("type")]
    private TransactionType type;

    [ObservableProperty]
    [JsonPropertyName("fromCurrency")]
    private string fromCurrency;

    [ObservableProperty]
    [JsonPropertyName("toCurrency")]
    private string toCurrency;

    [ObservableProperty]
    [JsonPropertyName("amount")]
    private double amount;

    [ObservableProperty]
    [JsonPropertyName("idType")]
    private string idType;

    [ObservableProperty]
    [JsonPropertyName("idNumber")]
    private string idNumber;


    public TransactionModel()
    {
        this.Id = id;
        this.Type = type;
        this.FromCurrency = fromCurrency;
        this.ToCurrency = toCurrency;
        this.Amount = amount;
        this.IdType = idType;
        this.IdNumber = idNumber;
    }

    public TransactionModel(TransactionEntity entity)
    {
        this.Id = entity.Id;
        this.Type = entity.Type;
        this.FromCurrency = entity.FromCurrency;
        this.ToCurrency = entity.ToCurrency;
        this.Amount = entity.Amount;
        this.IdType = entity.IDType;
        this.IdNumber = entity.IDNumber;
    }

    public TransactionEntity ToEntity()
    {
        return new TransactionEntity
        {
            Id = this.Id,
            Type = this.Type,
            FromCurrency = this.FromCurrency,
            ToCurrency = this.ToCurrency,
            Amount = this.Amount,
            IDType = this.IdType,
            IDNumber = this.IdNumber
        };
    }

    public void ToEntity(TransactionEntity entity)
    {
        entity.Id = this.Id;
        entity.Type = this.Type;
        entity.FromCurrency = this.FromCurrency;
        entity.ToCurrency = this.ToCurrency;
        entity.Amount = this.Amount;
        entity.IDType = this.IdType;
        entity.IDNumber = this.IdNumber;
    }
}
