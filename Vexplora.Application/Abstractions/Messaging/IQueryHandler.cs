using Vexplora.Domain.Abstractions;

using MediatR;

namespace Vexplora.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
