using Autofac;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration;

public sealed class AssetsCompositionRoot
{
    private static IContainer? s_container;

    internal static void SetContainer(IContainer container)
    {
        s_container = container;
    }

    public static ILifetimeScope BeginLifetimeScope()
    {
        return s_container!.BeginLifetimeScope();
    }
}
