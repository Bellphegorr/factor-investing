using FactorInvesting.Modules.Assets.Application.Contracts;
using FactorInvesting.Modules.Assets.Application.Securities.AddSecurity;
using FactorInvesting.Modules.Assets.Application.Securities.GetSecurities;
using FactorInvesting.Modules.Assets.Domain.Securities;
using Microsoft.AspNetCore.Mvc;

namespace FactorInvesting.Apps.API.Modules.Assets;

[ApiController]
[Route("api/assets")]
public class AssetsController(IAssetsModule assetsModule) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetSecuritiesQuery();
        var securities = await assetsModule.ExecuteQueryAsync(query);
        return Ok(securities);
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var command = new AddSecurityCommand()
        {
            Id = Guid.NewGuid(),
            Name = "Security Name",
            Type = SecurityTypes.Equity
        };
        await assetsModule.ExecuteCommandAsync(command);
        return Ok();
    }
}
