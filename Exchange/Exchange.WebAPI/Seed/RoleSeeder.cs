namespace Exchange.WebAPI.Seed;

public static class RoleSeeder
{
    private static readonly string[] DefaultRoles = new[] { "Admin", "User" };

    public static async Task SeedRolesAsync(IServiceProvider services, IEnumerable<string>? roles)
    {
        roles ??= DefaultRoles;

        var scope = services.CreateScope();
        var provider = scope.ServiceProvider;
        var roleManager = provider.GetRequiredService<RoleManager<RoleEntity>>();

        foreach (var roleName in roles)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                continue;

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var role = new RoleEntity
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpperInvariant()
                };

                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors);
                    throw new InvalidOperationException($"Failed to create role '{roleName}': {errors}");
                }
            }
        }
    }
}