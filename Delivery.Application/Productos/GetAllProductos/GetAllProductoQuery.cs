

using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetAllRestaurantes;

public sealed record GetAllProductoQuery : IQuery<List<ProductoDto>>
{

    
}