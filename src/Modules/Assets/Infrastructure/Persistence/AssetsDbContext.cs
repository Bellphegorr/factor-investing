using FactorInvesting.Modules.Assets.Domain.Securities;

using Microsoft.EntityFrameworkCore;

namespace FactorInvesting.Modules.Assets.Infrastructure.Persistence;

internal class AssetsDbContext(DbContextOptions<AssetsDbContext> options) : DbContext(options)
{
    public DbSet<Security> Securities { get; set; }
}
