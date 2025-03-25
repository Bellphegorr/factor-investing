using Autofac;
using FactorInvesting.Modules.Assets.Infrastructure;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;
using Xunit;

namespace FactorInvesting.IntegrationTests.Securities.GetSecurities;

public class GetSecuritiesTest(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetEndpointsReturnSuccessAndCorrectContentType()
    {
        var client = customWebApplicationFactory.CreateClient();
        var response = await client.GetAsync("/api/assets");
        response.EnsureSuccessStatusCode();
    }
}

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>, IAsyncLifetime
    where TProgram : class
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
        .WithDatabase("factor_investing")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .WithPortBinding(5432)
        .Build();

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _postgreSqlContainer.DisposeAsync();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var connectionString = _postgreSqlContainer.GetConnectionString();
        Environment.SetEnvironmentVariable("ConnectionStrings:AssetsDb", connectionString);
        var host = base.CreateHost(builder);
        var scope = AssetsCompositionRoot.BeginLifetimeScope();
        var dbContext = scope.Resolve<AssetsContext>();
        dbContext.Database.Migrate();
        return host;
    }
}
