

using Delivery.Application.Abstractions.Messaging;

namespace Delivery.Application.Restaurantes.Register;

public record RegisterRestauranteComand(


    string Nombre,
    string Descripcion,
    string LogoUrl,
    int TiempoEntrega

):ICommand<Guid>;

