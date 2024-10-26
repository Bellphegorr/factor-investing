using Autofac;
using FactorInvesting.BuildingBlocks.Application.Data;
using FactorInvesting.BuildingBlocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration.DataAccess;

internal sealed class DataAccessModule(string connectionString) : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var thisAssembly = typeof(DataAccessModule).Assembly;
        builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<AssetsContext>();
                dbContextOptionsBuilder.UseNpgsql(connectionString);
                return new AssetsContext(dbContextOptionsBuilder.Options);
            })
            .As<AssetsContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
        builder
            .RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", connectionString)
            .InstancePerLifetimeScope();
        builder
            .RegisterAssemblyTypes(thisAssembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
