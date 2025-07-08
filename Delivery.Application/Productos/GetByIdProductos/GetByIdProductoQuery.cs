

using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Productos.GetByIdProductos;

public sealed record GetByIdProductoQuery : IQuery<ProductoDto>
{

    public Guid Id { get; set; }


}

