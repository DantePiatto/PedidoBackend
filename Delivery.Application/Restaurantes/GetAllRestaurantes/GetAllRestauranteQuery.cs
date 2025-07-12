

using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetAllRestaurantes;

public sealed record GetAllRestauranteQuery : IQuery<List<RestauranteDto>>
{

    
}