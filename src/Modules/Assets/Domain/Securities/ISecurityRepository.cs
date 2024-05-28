namespace FactorInvesting.Modules.Assets.Domain.Securities;

public interface ISecurityRepository
{
    Task AddAsync(Security security);
}
