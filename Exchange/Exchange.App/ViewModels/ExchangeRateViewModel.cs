using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using FluentValidation;
using FluentValidation.Results;

namespace Exchange.App.ViewModels;

public partial class ExchangeRateViewModel(IExchangeRateService exchangeRateService, IValidator<ExchangeRateModel> validator) : ExchangeRateModel, IQueryAttributable
{
    [ObservableProperty]
    private ValidationResult? validationResult;

    [ObservableProperty]
    private string formTitle = "Set exchange rates";

    public IAsyncRelayCommand SaveRatesCommand => new AsyncRelayCommand(OnSaveAsync);

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("Exchange rate", out var value) || value is not ExchangeRateModel model)
            return;

        Id = model.Id;
        DateTimeNow = model.ExchangeDate;
        DateTimeNowString = model.ExchangeDate.ToString("yyyy-MM-dd");
        UsdToHuf = model.UsdtoHUF;
        GbpToHuf = model.GbptoHUF;
        ChfToHuf = model.ChftoHUF;
        FormTitle = "Edit exchange rate";
    }

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

        bool isError;
        string? errorMessage;

        if (Id > 0)
        {
            var result = await exchangeRateService.UpdateAsync(model);
            isError = result.IsError;
            errorMessage = result.IsError ? result.FirstError.Description : null;
        }
        else
        {
            var result = await exchangeRateService.CreateAsync(model);
            isError = result.IsError;
            errorMessage = result.IsError ? result.FirstError.Description : null;
        }

        var message = isError ? errorMessage : "Exchange rate saved successfully.";
        var title = isError ? "Error" : "Success";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private ExchangeRateModel CreateModelForValidation() => new()
    {
        Id = Id,
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
