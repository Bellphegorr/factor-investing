using System.Data;
using FactorInvesting.BuildingBlocks.Application.Data;
using Npgsql;

namespace FactorInvesting.BuildingBlocks.Infrastructure.Data;

public class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory, IDisposable
{
    private IDbConnection? _connection;

    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
            _connection.Close();
        GC.SuppressFinalize(this);
    }

    public IDbConnection CreateNewConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

    public string GetConnectionString()
    {
        return connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = CreateNewConnection();
            _connection.Open();
        }
        return _connection;
    }
}
