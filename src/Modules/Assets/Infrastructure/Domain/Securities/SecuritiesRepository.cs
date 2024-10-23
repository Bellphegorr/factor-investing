using FactorInvesting.Modules.Assets.Domain.Securities;
using FactorInvesting.Modules.Assets.Infrastructure.Persistence;

namespace FactorInvesting.Modules.Assets.Infrastructure.Domain.Securities;

internal class SecuritiesRepository(AssetsContext context) : ISecurityRepository
{
    private readonly AssetsContext _context = context;

    public async Task AddAsync(Security security)
    {
        await _context.Securities.AddAsync(security);
        await _context.SaveChangesAsync();
    }
}