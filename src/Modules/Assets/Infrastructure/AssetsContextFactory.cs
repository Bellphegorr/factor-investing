using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FactorInvesting.Modules.Assets.Infrastructure;

internal class UserContextFactory : IDesignTimeDbContextFactory<AssetsContext>
{
    public AssetsContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder();
        builder.AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly(), true);
        var configuration = builder.Build();
        var databaseConnectionString =
            args.Length > 0 ? args[0] : configuration.GetConnectionString("Postgres");
        var optionsBuilder = new DbContextOptionsBuilder<AssetsContext>();
        optionsBuilder.UseNpgsql("Server=database;Database=factor_investing;User Id=postgres;Password=postgres;");
        return new AssetsContext(optionsBuilder.Options);
    }
}
