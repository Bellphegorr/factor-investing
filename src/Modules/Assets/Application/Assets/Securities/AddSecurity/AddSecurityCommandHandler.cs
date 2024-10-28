using CompanyName.MyMeetings.Modules.Administration.Application.Configuration.Commands;
using FactorInvesting.Modules.Assets.Domain.Securities;

namespace FactorInvesting.Modules.Assets.Application.Assets.Securities.AddSecurity;

internal sealed class AddSecurityCommandHandler(ISecurityRepository securityRepository)
    : ICommandHandler<AddSecurityCommand>
{
    private readonly ISecurityRepository _securityRepository = securityRepository;

    public async Task Handle(AddSecurityCommand request, CancellationToken cancellationToken)
    {
        var security = Security.Create(request.Id, request.Name, request.Type);
        await _securityRepository.AddAsync(security);
    }
}
