using CommunityToolkit.Mvvm.ComponentModel;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Exchange.App.ViewModels;

[ObservableObject]
public partial class ListExchangeRatesViewModel(IExchangeRateService exchangeRateService) 
{
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }

    [ObservableProperty]
    public ObservableCollection<ExchangeRateModel> exchangeRates;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfExchangeRatesInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadExchangeRatesAsync();
    }

    private async Task LoadExchangeRatesAsync()
    {
        isLoading = true;

        var result = await exchangeRateService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Exchange rates are not loaded!", "OK");
            return;
        }

        ExchangeRates = new ObservableCollection<ExchangeRateModel>(result.Value.Items);
        numberOfExchangeRatesInDB = result.Value.Count;

        hasNextPage = numberOfExchangeRatesInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadExchangeRatesAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadExchangeRatesAsync();
    }
}

