using Dapper;
using FactorInvesting.BuildingBlocks.Application.Configuration.Queries;
using FactorInvesting.BuildingBlocks.Application.Contracts;
using FactorInvesting.BuildingBlocks.Application.Data;

namespace FactorInvesting.Modules.Assets.Application.Assets.Securities.GetSecurities;

public sealed class GetSecuritiesQuery : IQuery<object> { }

internal sealed class GetSecuritiesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetSecuritiesQuery, object>
{
    public async Task<object> Handle(
        GetSecuritiesQuery request,
        CancellationToken cancellationToken
    )
    {
        var connection = sqlConnectionFactory.GetOpenConnection();
        return await connection.QueryAsync<object>("SELECT * FROM assets.\"Securities\"");
    }
}
