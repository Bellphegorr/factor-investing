using FactorInvesting.BuildingBlocks.Application.Contracts;

namespace FactorInvesting.BuildingBlocks.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);

    Task EnqueueAsync<T>(ICommand<T> command);
}
