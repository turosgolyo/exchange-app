namespace Exchange.App.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);


    private async Task OnExitAsync()
    {
        await Task.Delay(1);
        Application.Current.Quit();
    }
}

