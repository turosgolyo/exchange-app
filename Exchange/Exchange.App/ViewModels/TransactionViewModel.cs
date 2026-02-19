using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Enums;
using Exchange.Domain.Models;
using Exchange.Services.Transaction;
using System.Collections.ObjectModel;

namespace Exchange.App.ViewModels;

public partial class TransactionViewModel(ITransactionService transactionService): TransactionModel
{
    [ObservableProperty]
    public ObservableCollection<string> transactionTypes = [ "Buy", "Sell" ];
}