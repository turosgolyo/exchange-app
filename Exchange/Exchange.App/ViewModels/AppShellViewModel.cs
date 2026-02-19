using CommunityToolkit.Mvvm.ComponentModel;

namespace Exchange.App.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand AddExchangeRateCommand => new AsyncRelayCommand(OnAddExchangeRateAsync);
    public IAsyncRelayCommand AddTransactionCommand => new AsyncRelayCommand(OnAddTransactionAsync);

    private async Task OnAddTransactionAsync()
    {
        await Task.Delay(1);
        await Shell.Current.GoToAsync(nameof(ExchangeRateView)); ;
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
