

namespace Delivery.Application.Restaurantes.UpdateRestaurantes;

public sealed record UpdateRestauranteRequest(

    string Id,
    string Nombre,
    string Descripcion,
    string LogoUrl,
    int TiempoEntrega,
    bool Activo
);