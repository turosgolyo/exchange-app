using Exchange.Shared.Validators;
using Exchange.Services.ExchangeRate;
using Exchange.Services.Transaction;
using FluentValidation;

namespace Exchange.App.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();

        //VIEWS
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<ExchangeRateView>();
        builder.Services.AddTransient<ListExchangeRatesView>();
        builder.Services.AddTransient<TransactionView>();
        builder.Services.AddTransient<ExchangeRatesGraphView>();

        //VIEWMODELS
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<ExchangeRateViewModel>();
        builder.Services.AddTransient<ListExchangeRatesViewModel>();
        builder.Services.AddTransient<TransactionViewModel>();
        builder.Services.AddTransient<ExchangeRatesGraphViewModel>();

        //SERVICES
        builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();
        builder.Services.AddTransient<ITransactionService, TransactionService>();

        return builder;
    }
}
