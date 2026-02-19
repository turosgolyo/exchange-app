using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exchange.App.ViewModels;

public partial class ExchangeRateViewModel(IExchangeRateService exchangeRateService) : ExchangeRateModel
{

    public IAsyncRelayCommand SaveRatesCommand => new AsyncRelayCommand(OnSaveAsync);

    [ObservableProperty]
    private DateTime dateTimeNow = DateTime.Today;

    [ObservableProperty]
    private string dateTimeNowString = DateTime.Today.ToString("yyyy-MM-dd");

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
            ExchangeDate = DateTimeNow,
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
