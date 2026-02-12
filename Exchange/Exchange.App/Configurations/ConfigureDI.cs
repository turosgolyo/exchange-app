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

        //VIEWMODELS
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<ExchangeRateViewModel>();

        //SERVICES
        builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();

        return builder;
    }
}
