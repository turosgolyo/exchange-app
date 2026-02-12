namespace Exchange.App.Views;

public partial class ExchangeRateView : ContentPage
{
    public ExchangeRateViewModel ViewModel => this.BindingContext as ExchangeRateViewModel;

    public static string Name => nameof(ExchangeRateView);

    public ExchangeRateView(ExchangeRateViewModel viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}

