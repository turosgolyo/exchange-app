using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using FluentValidation;
using FluentValidation.Results;

namespace Exchange.App.ViewModels;

public partial class ExchangeRateViewModel(IExchangeRateService exchangeRateService, IValidator<ExchangeRateModel> validator) : ExchangeRateModel
{
    [ObservableProperty]
    private ValidationResult? validationResult;

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
        if (!Validate())
        {
            return;
        }

        var model = CreateModelForValidation();

        var result = await exchangeRateService.CreateAsync(model);

        var message = result.IsError
            ? result.FirstError.Description
            : "Exchange rate saved successfully.";

        var title = result.IsError ? "Error" : "Success";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private ExchangeRateModel CreateModelForValidation() => new()
    {
        ExchangeDate = DateTimeNow,
        UsdtoHUF = UsdToHuf,
        GbptoHUF = GbpToHuf,
        ChftoHUF = ChfToHuf
    };

    private bool Validate()
    {
        var model = CreateModelForValidation();
        var validationResult = validator.Validate(model);
        ValidationResult = validationResult;

        return validationResult.IsValid;
    }
}
