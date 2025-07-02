using System.Linq.Expressions;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Parametros;
using Microsoft.EntityFrameworkCore.Query;

namespace Vexplora.Application.Paginations;

public interface IPaginationParametrosRepository
{
    Task<PagedResults<Parametro,ParametroId>> GetPaginationAsync(
        Expression<Func<Parametro,bool>> predicate,
        Func<IQueryable<Parametro>, IIncludableQueryable<Parametro,object>> includes,
        int page,
        int pageSize,
        string orderBy,
        bool ascending,
        bool disableTracking = true 
    );
}