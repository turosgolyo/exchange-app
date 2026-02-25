using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Enums;
using Exchange.Domain.Models;
using Exchange.Services.Transaction;
using System.Collections.ObjectModel;
using Windows.Globalization;

namespace Exchange.App.ViewModels;

public partial class TransactionViewModel(ITransactionService transactionService): TransactionModel
{
    [ObservableProperty]
    public ICollection<string> transactionTypes = [TransactionType.Sell.ToString(), TransactionType.Buy.ToString()];

    [ObservableProperty]
    public ICollection<string> currency = [TransactionCurrency.HUF.ToString(), TransactionCurrency.USD.ToString(), TransactionCurrency.CHF.ToString(), TransactionCurrency.GBP.ToString()];

    [ObservableProperty]
    public ICollection<string> idTypes = [IdType.IDCard.ToString(), IdType.Passport.ToString()];

    [ObservableProperty]
    public TransactionModel newTransaction = new();

    public IAsyncRelayCommand SaveTransactionCommand => new AsyncRelayCommand(OnSaveTransactionAsync);

    private async Task OnSaveTransactionAsync()
    {
        var result = await transactionService.CreateAsync(NewTransaction);

        var message = result.IsError
           ? result.FirstError.Description
           : "Exchange rate saved successfully.";

        var title = result.IsError ? "Error" : "Success";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private void Amount_ValueChanged(object sender, Syncfusion.Maui.Toolkit.NumericEntry.NumericEntryValueChangedEventArgs e)
    {
        if (NewTransaction != null && e.NewValue.HasValue)
        {
            NewTransaction.Amount = e.NewValue.Value;
        }
    }
}