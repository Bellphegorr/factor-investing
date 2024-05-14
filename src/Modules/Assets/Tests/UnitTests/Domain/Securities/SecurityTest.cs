using FactorInvesting.Modules.Assets.Domain.Securities;

using FluentAssertions;

namespace FactorInvesting.Modules.Assets.Tests.UnitTests.Domain.Securities;

public class SecurityTest
{
    [Fact]
    public void Security_Constructor_WithValidParameters_ShouldCreateSecurity()
    {
        var securityId = Guid.NewGuid();
        var securityName = "SecurityName";
        var securityType = SecurityTypes.Equity;
        var security = Security.Create(securityId, securityName, securityType);
        security.Id.Should().Be(securityId);
        security.Name.Should().Be(securityName);
        security.Type.Should().Be(securityType);
    }

    [Fact]
    public void Security_Constructor_WithInvalidParameters_ShouldThrowException()
    {
        var securityId = Guid.NewGuid();
        var securityName = "SecurityName";
        var securityType = SecurityTypes.Equity;
        Action action = () => Security.Create(Guid.Empty, securityName, securityType);
        action.Should().Throw<ArgumentException>().WithMessage("Security Id cannot be empty.");
        action = () => Security.Create(securityId, string.Empty, securityType);
        action.Should().Throw<ArgumentException>().WithMessage("Security Name cannot be empty.");
        action = () => Security.Create(securityId, securityName, (SecurityTypes)100);
        action.Should().Throw<ArgumentException>().WithMessage("Security Type is not valid.");
    }
}
