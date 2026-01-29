namespace Exchange.App.ViewModels;

public partial class LoginViewModel
{
    public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(OnLogin);

    private async Task OnLogin()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(MainView.Name);
    }
}
