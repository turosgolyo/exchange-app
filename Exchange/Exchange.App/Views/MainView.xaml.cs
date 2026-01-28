using Exchange.App.ViewModels;

namespace Exchange.App.Views;

public partial class MainView : ContentPage
{
	public MainViewModel ViewModel => this.BindingContext as MainViewModel;
	public static string Name => nameof(MainView);
	public MainView()
	{
		this.BindingContext = new MainViewModel();

		InitializeComponent();
	}
}