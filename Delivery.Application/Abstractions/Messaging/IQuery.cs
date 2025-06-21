
using MediatR;
using Delivery.Domain.Abstractions;

namespace Delivery.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}