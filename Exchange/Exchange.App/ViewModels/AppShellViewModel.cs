using CommunityToolkit.Mvvm.ComponentModel;

namespace Exchange.App.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand AddExchangeRateCommand => new AsyncRelayCommand(OnAddExchangeRateAsync);

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
