
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Shared;

namespace Delivery.Application.Productos.GetByRestaurantePaginationProductos;

public sealed record GetByRestaurantePaginationProductoQuery : PaginationParams, IQuery<PagedResults<ProductoDto>?>
{

    //public string? Token { get; set; }

    public string? RestauranteId { get; set; }

    

}