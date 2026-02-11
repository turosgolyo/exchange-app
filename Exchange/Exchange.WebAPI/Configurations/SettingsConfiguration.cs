using Exchange.Domain.Models.Settings;
using System.Reflection.Metadata.Ecma335;

namespace Exchange.WebAPI.Configurations;

public static class SettingsConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder LoadSettings()
        {
            builder.Services.Configure<JWTSettingsModel>(builder.Configuration.GetSection("JWT"));

            return builder;
        }
        
    }
}

