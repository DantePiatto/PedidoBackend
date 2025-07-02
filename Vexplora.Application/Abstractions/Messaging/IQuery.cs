
using MediatR;
using Vexplora.Domain.Abstractions;

namespace Vexplora.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}