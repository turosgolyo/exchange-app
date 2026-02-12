using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exchange.App.ViewModels;

public partial class ExchangeRateViewModel : ExchangeRateModel
{
    private readonly IExchangeRateService exchangeRateService;

    public IAsyncRelayCommand SaveRatesCommand => new AsyncRelayCommand(OnSaveAsync);

    public ExchangeRateViewModel(IExchangeRateService exchangeRateService)
    {
        this.exchangeRateService = exchangeRateService;
    }

    [ObservableProperty]
    private DateTime date = DateTime.Today;

    [ObservableProperty]
    private double usdToHuf;

    [ObservableProperty]
    private double gbpToHuf;

    [ObservableProperty]
    private double chfToHuf;

    public IAsyncRelayCommand RateButtonCommand =>
        new AsyncRelayCommand(OnSaveAsync);

    private async Task OnSaveAsync()
    {
        var model = new ExchangeRateModel
        {
            ExchangeDate = date,
            UsdtoHUF = UsdToHuf,
            GbptoHUF = GbpToHuf,
            ChftoHUF = ChfToHuf
        };

        var result = await exchangeRateService.CreateAsync(model);

        var message = result.IsError
            ? result.FirstError.Description
            : "Exchange rate saved successfully.";

        var title = result.IsError ? "Error" : "Success";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
