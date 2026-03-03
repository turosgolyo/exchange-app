namespace Exchange.App.Views;

public partial class ExchangeRatesGraphView : ContentPage
{
    public ExchangeRatesGraphViewModel ViewModel => this.BindingContext as ExchangeRatesGraphViewModel;

    public static string Name => nameof(ExchangeRatesGraphView);

    public ExchangeRatesGraphView(ExchangeRatesGraphViewModel viewModel)
    {
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}