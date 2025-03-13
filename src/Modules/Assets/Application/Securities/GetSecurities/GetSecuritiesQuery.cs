using FactorInvesting.BuildingBlocks.Application.Contracts;

namespace FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;

public sealed class GetSecuritiesQuery : IQuery<IEnumerable<SecuritiesResponse>> { }
