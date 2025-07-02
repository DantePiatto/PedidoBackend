using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Parametros;
using Vexplora.Domain.Shared;

namespace Vexplora.Application.Parametros.GetParametroByPagination;

public sealed record GetParametroByPaginationQuery : PaginationParams, IQuery<PagedResults<ParametroDto>?>
{
    public string? Dependencia {get;set;}
}