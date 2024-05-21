using FactorInvesting.BuildingBlocks.Application.Contracts;

namespace FactorInvesting.BuildingBlocks.Application.Configuration.Commands;

public abstract class InternalCommandBase(Guid id) : ICommand
{
    public Guid Id { get; } = id;
}

public abstract class InternalCommandBase<TResult> : ICommand<TResult>
{
    protected InternalCommandBase()
    {
        Id = Guid.NewGuid();
    }

    protected InternalCommandBase(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
