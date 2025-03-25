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
var configuration = app.Services.GetRequiredService<IConfiguration>();
var connectionString = configuration.GetConnectionString("AssetsDb");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
Configure(connectionString!);
app.Run();

static void Configure(string connectionString)
{
    AssetsStartup.Initialize(connectionString);
}

public partial class Program { }
