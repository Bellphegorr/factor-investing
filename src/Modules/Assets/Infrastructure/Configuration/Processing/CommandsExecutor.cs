using Autofac;
using FactorInvesting.BuildingBlocks.Application.Contracts;
using MediatR;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration.Processing;

internal sealed class CommandsExecutor
{
    internal static async Task ExecuteAsync(ICommand command)
    {
        using var scope = AssetsCompositionRoot.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }
}
