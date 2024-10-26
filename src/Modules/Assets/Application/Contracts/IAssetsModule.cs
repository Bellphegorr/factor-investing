using FactorInvesting.BuildingBlocks.Application.Contracts;

namespace FactorInvesting.Modules.Assets.Application.Contracts;

public interface IAssetsModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
