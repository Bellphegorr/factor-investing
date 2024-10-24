using FactorInvesting.BuildingBlocks.Application.Contracts;
using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration.Processing;

namespace FactorInvesting.Modules.Assets.Infrastructure.Application.Contracts;

public class AssetsModule : IAssetsModule
{
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.ExecuteAsync(command);
    }
}
