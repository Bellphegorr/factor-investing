using FactorInvesting.Modules.Assets.Domain.Securities;

namespace FactorInvesting.Modules.Assets.Infrastructure.Domain.Securities;

public class SecuritiesRepository : ISecurityRepository
{
    public Task AddAsync(Security security)
    {
        throw new NotImplementedException();
    }
}