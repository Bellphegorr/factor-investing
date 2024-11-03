namespace FactorInvesting.Modules.Assets.Application.Assets.Securities.GetSecurities;

public sealed class SecuritiesResponse {
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }

}