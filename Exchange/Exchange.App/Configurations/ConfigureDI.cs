using Exchange.Domain.Database;
using Exchange.Domain.Database.Entities;
using Exchange.Services.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddTransient<ISecurityService, SecurityService>();
        builder.Services.AddDbContext<ApplicationDbContext>();
        builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();



        return builder;
    }
}
