using MediatR;

namespace FactorInvesting.BuildingBlocks.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult> { }
