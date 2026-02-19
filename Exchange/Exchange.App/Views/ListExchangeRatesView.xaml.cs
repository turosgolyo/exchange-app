namespace Exchange.App.Views;

public partial class ListExchangeRatesView : ContentPage
{
    public ListExchangeRatesViewModel ViewModel => this.BindingContext as ListExchangeRatesViewModel;

    public static string Name => nameof(ListExchangeRatesView);

    public ListExchangeRatesView(ListExchangeRatesViewModel viewModel)
    {
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}

