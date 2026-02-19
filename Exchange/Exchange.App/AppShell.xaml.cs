using Exchange.App.ViewModels;

namespace Exchange.App;

public partial class AppShell : Shell
{
    public AppShellViewModel ViewModel => this.BindingContext as AppShellViewModel;
    public static string Name => nameof(AppShell);
    public AppShell()
    {
        this.BindingContext = new AppShellViewModel();
        InitializeComponent();
        ConfigureRoutes();
    }
    public static void ConfigureRoutes()
    {
        Routing.RegisterRoute(LoginView.Name, typeof(LoginView));
        Routing.RegisterRoute(MainView.Name, typeof(MainView));
        Routing.RegisterRoute(ExchangeRateView.Name, typeof(ExchangeRateView));
        Routing.RegisterRoute(TransactionView.Name, typeof(TransactionView));
    }
}
