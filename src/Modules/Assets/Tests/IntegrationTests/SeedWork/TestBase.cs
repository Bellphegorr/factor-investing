using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure;
using FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FactorInvesting.Modules.Assets.IntegrationTests.SeedWork;

public class TestBase : IDisposable
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
        AssetsContext.Database.ExecuteSqlRaw("DELETE FROM assets.\"Securities\"");
    }

    public void Dispose()
    {
        AssetsContext.SaveChanges();
        AssetsContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
