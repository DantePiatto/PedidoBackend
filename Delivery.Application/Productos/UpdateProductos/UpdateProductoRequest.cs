

namespace Delivery.Application.Productos.UpdateProductos;

public sealed record UpdateProductoRequest(


    string Id,
    int CategoriaId,
    string Nombre,
    string Descripcion,
    double Precio,
    string ImagenUrl,
    bool Activo

);