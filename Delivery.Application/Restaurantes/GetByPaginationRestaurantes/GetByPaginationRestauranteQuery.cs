
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;
using Delivery.Domain.Shared;

namespace Delivery.Application.Restaurantes.GetByPaginationRestaurantes;

public sealed record GetByPaginationRestauranteQuery : PaginationParams, IQuery<PagedResults<RestauranteDto>?>
{
    
    //public string? Token { get; set; }
}