

namespace Delivery.Application.Restaurantes.Register;

public record RegisterRestauranteRequest(


    string Nombre,
    string Descripcion,
    string LogoUrl,
    int TiempoEntrega

);