
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Shared;

namespace Delivery.Application.Productos.GetByCategoriaPaginationProductos;

public sealed record GetByCategoriaPaginationProductoQuery : PaginationParams, IQuery<PagedResults<ProductoDto>?>
{

    //public string? Token { get; set; }

    public string ? CategoriId { get; set; }

    

}