namespace Exchange.WebAPI.Configurations;

public static class DependencInjectionConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder ConfigureDI()
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            builder.Services.AddTransient<ISecurityService, SecurityService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ITransactionService, TransactionService>();
            builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();


            return builder;
        }
    }
}

