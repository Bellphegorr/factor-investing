using FactorInvesting.Modules.Assets.Domain.Securities;
using Microsoft.EntityFrameworkCore;

namespace FactorInvesting.Modules.Assets.Infrastructure;

public sealed class AssetsContext(DbContextOptions<AssetsContext> options) : DbContext(options)
{
    public DbSet<Security> Securities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssetsContext).Assembly);
    }
}
