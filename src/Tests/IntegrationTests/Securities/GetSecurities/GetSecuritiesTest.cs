using Autofac;
using Autofac.Extensions.DependencyInjection;
using FactorInvesting.Apps.API.Modules.Assets;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace FactorInvesting.IntegrationTests.Securities.GetSecurities;

public class GetSecuritiesTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _customWebApplicationFactory;

    public GetSecuritiesTest(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    {
        _customWebApplicationFactory = customWebApplicationFactory;
    }

    [Fact]
    public async Task GetEndpointsReturnSuccessAndCorrectContentType()
    {
        var client = _customWebApplicationFactory.CreateClient();
        var response = await client.GetAsync("/api/assets");
        response.EnsureSuccessStatusCode();
    }
}

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule(new AssetsAutoFacModule());
            AssetsStartup.Initialize("");
        });
        return base.CreateHost(builder);
    }
}
