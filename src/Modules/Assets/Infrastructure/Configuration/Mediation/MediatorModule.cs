using System.Reflection;
using Autofac;
using CompanyName.MyMeetings.Modules.Administration.Application.Configuration.Commands;
using MediatR;
using MediatR.Pipeline;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration.Mediation;

internal sealed class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var thisAssembly = typeof(MediatorModule).Assembly;
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
        foreach (var mediatorOpenType in mediatorOpenTypes)
        {
            builder
                .RegisterAssemblyTypes(thisAssembly, Assemblies.Application)
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
    }
}
