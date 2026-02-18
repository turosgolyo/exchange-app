using CommunityToolkit.Mvvm.ComponentModel;
using ErrorOr;

namespace Exchange.App.ViewModels;

public partial class LoginViewModel() : ObservableObject
{
    
    public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(OnLogin);

    private async Task OnLogin()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ExchangeRateView.Name);
    }
}
