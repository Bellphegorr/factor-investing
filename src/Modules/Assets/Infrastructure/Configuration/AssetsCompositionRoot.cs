using Autofac;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration;

internal sealed class AssetsCompositionRoot
{
    private static IContainer? s_container;

    internal static void SetContainer(IContainer container)
    {
        s_container = container;
    }

    internal static ILifetimeScope BeginLifetimeScope()
    {
        return s_container!.BeginLifetimeScope();
    }
}
