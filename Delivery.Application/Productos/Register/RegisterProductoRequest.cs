

namespace Delivery.Application.Productos.Register;

public record RegisterProductoRequest(

    Guid RestaurantesId,
    int CategoriaId,
    string Nombre,
    string Descripcion,
    double Precio,
    string ImagenUrl




);