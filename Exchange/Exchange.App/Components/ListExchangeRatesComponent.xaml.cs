using Exchange.Domain.Models;

namespace Exchange.App.Components;

public partial class ListExchangeRatesComponent : ContentView
{
    public ExchangeRateModel ExchangeRate
    {
        get => (ExchangeRateModel)GetValue(ExchangeRateProperty);
        set => SetValue(ExchangeRateProperty, value);
    }

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Exchange rate", this.ExchangeRate}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ExchangeRateView.Name, navigationQueryParameter);
    }

    #region Bindable Properties

    public static readonly BindableProperty ExchangeRateProperty = BindableProperty.Create(
        propertyName: nameof(ExchangeRate),
        returnType: typeof(ExchangeRateModel),
        declaringType: typeof(ListExchangeRatesComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        propertyName: nameof(DeleteCommand),
        returnType: typeof(IAsyncRelayCommand),
        declaringType: typeof(ListExchangeRatesComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(CommandParameter),
        returnType: typeof(string),
        declaringType: typeof(ListExchangeRatesComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
    );

    #endregion

    public ListExchangeRatesComponent()
    {
        InitializeComponent();
    }
}