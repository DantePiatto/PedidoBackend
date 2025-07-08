
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Productos;

namespace Delivery.Application.Productos.UpdateProductos;
public sealed record UpdateProductoCommand(

    ProductoId Id,
    int CategoriaId,
    string Nombre,
    string Descripcion,
    double Precio,
    string ImagenUrl,
    bool Activo

): ICommand<Guid>;