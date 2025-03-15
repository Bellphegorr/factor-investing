using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;
using FactorInvesting.Modules.Assets.Domain.Securities;
using FactorInvesting.Modules.Assets.Infrastructure;
using FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
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
    }
}

public class TestBase
{
    protected string ConnectionString { get; private set; }
    protected IAssetsModule AssetsModule { get; private set; }
    protected AssetsContext AssetsContext { get; private set; }

    public TestBase()
    {
        ConnectionString =
            "Server=database;Database=factor_investing;User Id=postgres;Password=postgres;";
        AssetsStartup.Initialize(ConnectionString);
        AssetsModule = new AssetsModule();
        AssetsContext = new AssetsContext(
            new DbContextOptionsBuilder<AssetsContext>().UseNpgsql(ConnectionString).Options
        );
    }
}
