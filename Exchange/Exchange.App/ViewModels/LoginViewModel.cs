using CommunityToolkit.Mvvm.ComponentModel;
using ErrorOr;
using Exchange.Domain.Models.Requests.Security;
using Exchange.Domain.Models.Responses;
using Exchange.Services.Security;

namespace Exchange.App.ViewModels;

public partial class LoginViewModel(ISecurityService securityService) : ObservableObject
{
    [ObservableProperty]
    public string email;

    [ObservableProperty]
    public string password;
    
    public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(OnLogin);

    private async Task OnLogin()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ExchangeRateView.Name);
    }
}
