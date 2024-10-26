using Autofac;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration.DataAccess;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration.Mediation;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration;

public sealed class AssetsStartup
{
    public static void Initialize(string connectionString)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new DataAccessModule(connectionString));
        builder.RegisterModule(new MediatorModule());
        var container = builder.Build();
        AssetsCompositionRoot.SetContainer(container);
    }
}
