using Autofac;
using Autofac.Extensions.DependencyInjection;
using FactorInvesting.Apps.API.Modules.Assets;
using FactorInvesting.Modules.Assets.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new AssetsAutoFacModule())
);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
Configure();
app.Run();

static void Configure()
{
    var connectionString =
        "Server=database;Database=factor_investing;User Id=postgres;Password=postgres;";
    AssetsStartup.Initialize(connectionString);
}
