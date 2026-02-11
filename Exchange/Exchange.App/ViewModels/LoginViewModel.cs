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
        LoginRequestModel req = new LoginRequestModel
        {
            Email = Email,
            Password = Password
        };
        ErrorOr<TokenResponseModel> res = await securityService.LoginAsync(req);

        if (res.IsError)
        {
            return;
        }
        else
        {
            Shell.Current.ClearNavigationStack();
            await Shell.Current.GoToAsync(MainView.Name);
        }
    }
}
