
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Productos.DeleteProductos;

public sealed record DeleteProductoCommand(

    ProductoId Id

):ICommand<Guid>;