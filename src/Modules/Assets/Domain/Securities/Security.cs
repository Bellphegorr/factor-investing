using FactorInvesting.BuildingBlocks.Domain;

namespace FactorInvesting.Modules.Assets.Domain.Securities;

public class Security : Entity, IAggregateRoot
{
    public Guid Id { get; }
    public string Name { get; }
    public SecurityTypes Type { get; }

    private Security(Guid id, string name, SecurityTypes type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public static Security Create(Guid id, string name, SecurityTypes type) =>
        id == Guid.Empty
            ? throw new ArgumentException("Security Id cannot be empty.")
            : string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Security Name cannot be empty.")
                : !Enum.IsDefined(typeof(SecurityTypes), type)
                    ? throw new ArgumentException("Security Type is not valid.")
                    : new Security(id, name, type);
}
