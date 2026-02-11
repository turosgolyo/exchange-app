using Exchange.WebAPI.Configurations;
using Exchange.WebAPI.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDI()
       .LoadSettings()
       .ConfigureDatabase()
       .UseIdentity()
       .UseSecurity()
       .UseScalarOpenAPI();


builder.Services.AddOpenApi();

var app = builder.Build();

await RoleSeeder.SeedRolesAsync(app.Services, null);

app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();
app.UseScalarOpenAPI();

await app.RunAsync();
