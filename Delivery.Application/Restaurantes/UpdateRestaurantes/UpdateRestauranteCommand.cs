
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.UpdateRestaurantes;

public sealed record UpdateRestauranteCommand(

    RestauranteId Id,
    string Nombre,
    string Descripcion,
    string LogoUrl,
    int TiempoEntrega,
    bool Activo
):ICommand<Guid>;