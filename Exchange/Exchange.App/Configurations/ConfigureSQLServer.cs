namespace Exchange.DesktopApp.Configurations;

public static class ConfigureSQLServer
{
	public static MauiAppBuilder UseMsSqlServer(this MauiAppBuilder builder)
	{
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies()
                   .UseSqlServer(connectionString, options =>
                   {
                       options.MigrationsAssembly(DomainAssemblyReference.Assembly);
                       options.EnableRetryOnFailure();
                       options.CommandTimeout(300);
                   })
            );

		return builder;
	}
}
