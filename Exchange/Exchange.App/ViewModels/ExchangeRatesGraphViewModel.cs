using System.Collections.ObjectModel;

namespace Exchange.App.ViewModels;

public partial class ExchangeRatesGraphViewModel(IExchangeRateService exchangeRateService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ExchangeRateModel> exchangeRates = [];

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    private async Task OnAppearingAsync()
    {
        var result = await exchangeRateService.GetAllAsync();

        if (result.IsError)
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", "Failed to load exchange rates!", "OK");
            return;
        }

        ExchangeRates = new ObservableCollection<ExchangeRateModel>(result.Value.OrderBy(x => x.ExchangeDate));
    }
}
