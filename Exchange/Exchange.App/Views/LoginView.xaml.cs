namespace Exchange.App.Views;

public partial class LoginView : ContentPage
{
    public LoginViewModel ViewModel => this.BindingContext as LoginViewModel;
    public static string Name => nameof(LoginView);
    public LoginView(LoginViewModel viewModel)
    {
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}
