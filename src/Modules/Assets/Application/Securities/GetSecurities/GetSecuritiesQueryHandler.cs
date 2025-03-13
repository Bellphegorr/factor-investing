using Dapper;
using FactorInvesting.BuildingBlocks.Application.Configuration.Queries;
using FactorInvesting.BuildingBlocks.Application.Data;

namespace FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;

internal sealed class GetSecuritiesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetSecuritiesQuery, IEnumerable<SecuritiesResponse>>
{
    public async Task<IEnumerable<SecuritiesResponse>> Handle(
        GetSecuritiesQuery request,
        CancellationToken cancellationToken
    )
    {
        var connection = sqlConnectionFactory.GetOpenConnection();
        return await connection.QueryAsync<SecuritiesResponse>(
            $"""
               SELECT 
                   "SecurityId" AS {nameof(SecuritiesResponse.Id)},
                   "SecurityName" AS {nameof(SecuritiesResponse.Name)},
                   "SecurityType" AS {nameof(SecuritiesResponse.Type)}
               FROM assets."Securities"
            """
        );
    }
}
