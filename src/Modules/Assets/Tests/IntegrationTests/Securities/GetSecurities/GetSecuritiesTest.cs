using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;
using FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using Xunit;

namespace FactorInvesting.Modules.Assets.IntegrationTests.Securities.GetSecurities;

public sealed class GetSecuritiesTest : TestBase
{
    [Fact]
    public async Task GetSecurities()
    {
        var securities = await AssetsModule.ExecuteQueryAsync(new GetSecuritiesQuery());
        Assert.NotNull(securities);
        Assert.NotEmpty(securities);
    }
}

public class TestBase
{
    protected string ConnectionString { get; private set; }
    protected IAssetsModule AssetsModule { get; private set; }

    public TestBase()
    {
        ConnectionString =
            "Server=database;Database=factor_investing;User Id=postgres;Password=postgres;";
        AssetsStartup.Initialize(ConnectionString);
        AssetsModule = new AssetsModule();
    }
}
