
using Delivery.Application.Abstractions.Messaging;

namespace Delivery.Application.Productos.Register;

public record RegisterProductoCommand(

     Guid RestaurantesId,
    int CategoriaId,
    string Nombre,
    string Descripcion,
    double Precio,
    string ImagenUrl


):ICommand<Guid>;

