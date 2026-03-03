using CommunityToolkit.Mvvm.ComponentModel;

namespace Exchange.App.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand ExchangeRatesStatistics => new AsyncRelayCommand(OnExchangeRatesStatistics);
    public IAsyncRelayCommand AddExchangeRateCommand => new AsyncRelayCommand(OnAddExchangeRateAsync);
    public IAsyncRelayCommand ListExchangeRatesCommand => new AsyncRelayCommand(OnListExchangeRatesAsync);

    private async Task OnExchangeRatesStatistics()
    {
        await Task.Delay(1);
        await Shell.Current.GoToAsync(nameof(ExchangeRatesGraphView));
    }

    private async Task OnListExchangeRatesAsync()
    {
        await Task.Delay(1);
        await Shell.Current.GoToAsync(nameof(ListExchangeRatesView));
    }
    public IAsyncRelayCommand AddTransactionCommand => new AsyncRelayCommand(OnAddTransactionAsync);

    private async Task OnAddTransactionAsync()
    {
        await Task.Delay(1);
        await Shell.Current.GoToAsync(nameof(TransactionView)); ;
    }

    private async Task OnAddExchangeRateAsync()
    {
        await Task.Delay(1);
        await Shell.Current.GoToAsync(nameof(ExchangeRateView));
    }

    private async Task OnExitAsync()
    {
        await Task.Delay(1);
        Application.Current.Quit();
    }
}
