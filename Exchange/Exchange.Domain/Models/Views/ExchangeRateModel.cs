namespace Exchange.Domain.Models;

public partial class ExchangeRateModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("exchangeDate")]
    private DateTime exchangeDate;

    [ObservableProperty]
    [JsonPropertyName("usdtoHUF")]
    private double usdtoHUF;

    [ObservableProperty]
    [JsonPropertyName("gbptoHUF")]
    private double gbptoHUF;

    [ObservableProperty]
    [JsonPropertyName("chftoHUF")]
    private double chftoHUF;


    public ExchangeRateModel()
    {
        this.Id = id;
        this.ExchangeDate = exchangeDate;
        this.UsdtoHUF = usdtoHUF;
        this.GbptoHUF = gbptoHUF;
        this.ChftoHUF = chftoHUF;
    }

    public ExchangeRateModel(ExchangeRateEntity entity)
    {
        this.Id = entity.Id;
        this.ExchangeDate = entity.ExchangeDate;
        this.UsdtoHUF = entity.USDtoHUF;
        this.GbptoHUF = entity.GBPtoHUF;
        this.ChftoHUF = entity.CHFtoHUF;

    }

    public ExchangeRateEntity ToEntity()
    {
        return new ExchangeRateEntity
        {
            Id = this.Id,
            ExchangeDate = this.ExchangeDate,
            USDtoHUF = this.UsdtoHUF,
            GBPtoHUF = this.GbptoHUF,
            CHFtoHUF = this.ChftoHUF
        };
    }

    public void ToEntity(ExchangeRateEntity entity)
    {
        entity.Id = this.Id;
        entity.ExchangeDate = this.ExchangeDate;
        entity.USDtoHUF = this.UsdtoHUF;
        entity.GBPtoHUF = this.GbptoHUF;
        entity.CHFtoHUF = this.ChftoHUF;
    }
}
