using Autofac;
using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;

namespace FactorInvesting.Apps.API.Modules.Assets
{
    public class AssetsAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssetsModule>().As<IAssetsModule>().InstancePerLifetimeScope();
        }
    }
}
