using FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;
using FactorInvesting.Modules.Assets.Domain.Securities;
using FactorInvesting.Modules.Assets.Infrastructure;
using FactorInvesting.Modules.Assets.IntegrationTests.SeedWork;
using Xunit;

namespace FactorInvesting.Modules.Assets.IntegrationTests.Securities.GetSecurities;

public sealed class GetSecuritiesTest : TestBase
{
    [Fact]
    public async Task GetSecurities()
    {
        AssetsContext.Securities.Add(Security.Create(Guid.NewGuid(), "AAPL", SecurityTypes.Equity));
        AssetsContext.SaveChanges();
        var securities = await AssetsModule.ExecuteQueryAsync(new GetSecuritiesQuery());
        Assert.NotNull(securities);
        Assert.NotEmpty(securities);
        Assert.Single(securities);
    }
}
