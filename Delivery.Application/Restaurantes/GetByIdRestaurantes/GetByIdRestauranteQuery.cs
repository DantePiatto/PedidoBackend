

using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetByIdRestaurantes;

public sealed record GetByIdRestaurantesQuery : IQuery<RestauranteDto>
{

    public Guid Id { get; set; }


}

