using System.Collections.Generic;
using System.Reflection.Emit;

namespace Exchange.Domain.Database;


public sealed class ApplicationDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public override DbSet<UserEntity> Users { get; set; }
    public DbSet<ExchangeRateEntity> ExchangeRates {  get; set; }

    public DbSet<TransactionEntity> Transactions { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUser();
    }
}

