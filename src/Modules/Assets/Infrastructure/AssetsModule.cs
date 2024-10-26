using Autofac;
using FactorInvesting.BuildingBlocks.Application.Contracts;
using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration.Processing;
using MediatR;

namespace FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;

public class AssetsModule : IAssetsModule
{
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.ExecuteAsync(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = AssetsCompositionRoot.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
