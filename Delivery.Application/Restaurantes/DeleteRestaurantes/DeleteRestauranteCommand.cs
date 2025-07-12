
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.DeleteRestaurantes;

public sealed record DeleteRestauranteCommand(

    RestauranteId Id
):ICommand<Guid>;