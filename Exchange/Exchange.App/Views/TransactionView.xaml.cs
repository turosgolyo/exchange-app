namespace Exchange.App.Views;

public partial class TransactionView : ContentPage
{
	public TransactionViewModel ViewModel => this.BindingContext as TransactionViewModel;
	public static string Name = nameof(TransactionView);
	public TransactionView()
	{
		this.BindingContext = new TransactionViewModel();
		InitializeComponent();
	}
}