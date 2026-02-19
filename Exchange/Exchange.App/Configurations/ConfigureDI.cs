using Exchange.Services.ExchangeRate;
using Exchange.Services.Transaction;

namespace Exchange.App.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        //VIEWS
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<ExchangeRateView>();
        builder.Services.AddTransient<TransactionView>();

        //VIEWMODELS
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<ExchangeRateViewModel>();
        builder.Services.AddTransient<TransactionViewModel>();

        //SERVICES
        builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();
        builder.Services.AddTransient<ITransactionService, TransactionService>();

        return builder;
    }
}
