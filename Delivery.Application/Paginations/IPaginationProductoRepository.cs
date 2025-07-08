
using System.Linq.Expressions;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;
using Microsoft.EntityFrameworkCore.Query;


namespace Delivery.Application.Paginations;

public interface IPaginationProductoRepository
{
    Task<PagedResults<Producto, ProductoId>> GetPaginationAsync(
        Expression<Func<Producto,bool>> predicate,
        Func<IQueryable<Producto> , IIncludableQueryable<Producto,object>> includes,
        int page,
        int pageSize,
        string orderBy,
        bool ascending,
        bool disableTracking = true
    );
}