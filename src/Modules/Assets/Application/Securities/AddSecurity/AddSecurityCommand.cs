using FactorInvesting.BuildingBlocks.Application.Contracts;
using FactorInvesting.Modules.Assets.Domain.Securities;

namespace FactorInvesting.Modules.Assets.Application.Securities.AddSecurity;

public class AddSecurityCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SecurityTypes Type { get; set; }
}
