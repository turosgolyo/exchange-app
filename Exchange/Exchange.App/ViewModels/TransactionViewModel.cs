namespace Exchange.App.ViewModels;

public partial class TransactionViewModel(ITransactionService transactionService, IExchangeRateService exchangeRateService): TransactionModel
{
    [ObservableProperty]
    public ICollection<TransactionType> transactionTypes = [TransactionType.Sell, TransactionType.Buy];

    [ObservableProperty]
    public ICollection<TransactionCurrency> currency = [TransactionCurrency.HUF, TransactionCurrency.USD, TransactionCurrency.CHF, TransactionCurrency.GBP];

    [ObservableProperty]
    public ICollection<IdType> idTypes = [IdType.IDCard, IdType.Passport];

    [ObservableProperty]
    public TransactionModel newTransaction = new();

    public IAsyncRelayCommand SaveTransactionCommand => new AsyncRelayCommand(OnSaveTransactionAsync);

    private async Task OnSaveTransactionAsync()
    {
        var exchangeRateResult = await exchangeRateService.GetCurrentRateAsync();
        if (exchangeRateResult.IsError || exchangeRateResult.Value is null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No exchange rate found for today.", "OK");
            return;
        }


        var exchangeRate = exchangeRateResult.Value;
        NewTransaction.ExchangeRateId = exchangeRate.Id;
        NewTransaction.UserId = Guid.Parse("FB3D5D2A-620A-450C-2332-08DE7507F434");

        var result = await transactionService.CreateAsync(NewTransaction);

        var message = result.IsError ? result.FirstError.Description : "Transaction was successful!";

        var title = result.IsError ? "Error" : "Success";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}