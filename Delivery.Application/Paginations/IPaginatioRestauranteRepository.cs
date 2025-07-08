
using System.Linq.Expressions;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;
using Microsoft.EntityFrameworkCore.Query;


namespace Delivery.Application.Paginations;

public interface IPaginationRestauranteRepository
{
    Task<PagedResults<Restaurante, RestauranteId>> GetPaginationAsync(
        Expression<Func<Restaurante,bool>> predicate,
        Func<IQueryable<Restaurante> , IIncludableQueryable<Restaurante,object>> includes,
        int page,
        int pageSize,
        string orderBy,
        bool ascending,
        bool disableTracking = true
    );
}