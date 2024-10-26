using FactorInvesting.BuildingBlocks.Application.Contracts;
using MediatR;

namespace FactorInvesting.BuildingBlocks.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult> { }
