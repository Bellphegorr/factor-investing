using FactorInvesting.Modules.Assets.Domain.Securities;
using FactorInvesting.Modules.Assets.Infrastructure.Persistence;

namespace FactorInvesting.Modules.Assets.Infrastructure.Domain.Securities;

internal class SecuritiesRepository(AssetsDbContext context) : ISecurityRepository
{
    private readonly AssetsDbContext _context = context;

    public async Task AddAsync(Security security)
    {
        await _context.Securities.AddAsync(security);
        await _context.SaveChangesAsync();
    }
}