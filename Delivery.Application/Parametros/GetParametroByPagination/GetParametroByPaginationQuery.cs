using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Shared;

namespace Delivery.Application.Parametros.GetParametroByPagination;

public sealed record GetParametroByPaginationQuery : PaginationParams, IQuery<PagedResults<ParametroDto>?>
{
    public string? Dependencia {get;set;}
}