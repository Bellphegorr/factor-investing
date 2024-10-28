using FactorInvesting.Modules.Assets.Domain.Securities;

namespace FactorInvesting.Modules.Assets.Infrastructure.Domain.Securities;

internal sealed class SecurityRepository(AssetsContext context) : ISecurityRepository
{
    private readonly AssetsContext _context = context;

    public async Task AddAsync(Security security)
    {
        await _context.Securities.AddAsync(security);
        await _context.SaveChangesAsync();
    }
}