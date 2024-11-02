using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CompanyName.MyMeetings.Modules.Administration.Application.Configuration.Commands;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration.Mediation;

internal sealed class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var mediatorOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestHandler<>),
            typeof(IRequestPreProcessor<>),
            typeof(INotificationHandler<>),
            typeof(IStreamRequestHandler<,>),
            typeof(IRequestPostProcessor<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionAction<,>),
            typeof(ICommandHandler<>),
            typeof(ICommandHandler<,>)
        };
        var services = new ServiceCollection();
        foreach (var mediatorOpenType in mediatorOpenTypes)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly, Assemblies.Application)
                .AsClosedTypesOf(mediatorOpenType)
                .AsImplementedInterfaces();
        }
        builder
            .RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();
        builder
            .RegisterGeneric(typeof(RequestPostProcessorBehavior<,>))
            .As(typeof(IPipelineBehavior<,>));
        builder
            .RegisterGeneric(typeof(RequestPreProcessorBehavior<,>))
            .As(typeof(IPipelineBehavior<,>));
        builder
            .RegisterGeneric(typeof(RequestExceptionActionProcessorBehavior<,>))
            .As(typeof(IPipelineBehavior<,>));
        builder
            .RegisterGeneric(typeof(RequestExceptionProcessorBehavior<,>))
            .As(typeof(IPipelineBehavior<,>));
        builder.Populate(services);
    }
}
