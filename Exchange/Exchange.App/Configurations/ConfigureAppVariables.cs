namespace Exchange.App.Configurations;

public static class ConfigureAppVariables
{
    public static MauiAppBuilder UseAppConfigurations(this MauiAppBuilder builder)
    {
        var file = "appsettings.json";
        var stream = new MemoryStream(File.ReadAllBytes($"{file}"));

        var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

        builder.Configuration.AddConfiguration(config);

        return builder;
    }
}
