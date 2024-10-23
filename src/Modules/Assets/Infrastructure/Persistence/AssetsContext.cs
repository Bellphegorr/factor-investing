using FactorInvesting.Modules.Assets.Domain.Securities;

using Microsoft.EntityFrameworkCore;

namespace FactorInvesting.Modules.Assets.Infrastructure.Persistence;

internal class AssetsContext(DbContextOptions<AssetsContext> options) : DbContext(options)
{
    public DbSet<Security> Securities { get; set; }
}
