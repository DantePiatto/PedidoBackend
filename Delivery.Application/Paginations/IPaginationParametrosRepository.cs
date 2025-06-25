using System.Linq.Expressions;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Microsoft.EntityFrameworkCore.Query;

namespace Delivery.Application.Paginations;

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