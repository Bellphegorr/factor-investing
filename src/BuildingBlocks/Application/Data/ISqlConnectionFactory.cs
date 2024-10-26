using System.Data;

namespace FactorInvesting.BuildingBlocks.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}
