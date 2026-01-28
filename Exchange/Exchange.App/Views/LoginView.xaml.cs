using Exchange.App.ViewModels;

namespace Exchange.App.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginViewModel ViewModel => this.BindingContext as LoginViewModel;
        public static string Name => nameof(LoginView);
        public LoginView()
        {
            this.BindingContext = new LoginViewModel();
            InitializeComponent();
        }
    }
}
