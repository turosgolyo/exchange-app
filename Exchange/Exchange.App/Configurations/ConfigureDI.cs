namespace Exchange.App.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        //VIEWS
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<LoginView>();

        //VIEWMODELS
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();

        //SERVICES
    
        return builder;
    }
}
