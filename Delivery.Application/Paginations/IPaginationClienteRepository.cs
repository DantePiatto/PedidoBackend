// using System.Linq.Expressions;
// using Microsoft.EntityFrameworkCore.Query;
// using Delivery.Domain.Abstractions;
// using Delivery.Domain.Clientes;

// namespace Delivery.Application.Paginations;

// public interface IPaginationClienteRepository
// {
//     Task<PagedResults<Cliente, ClienteId>> GetPaginationAsync(
//         Expression<Func<Cliente,bool>> predicate,
//         Func<IQueryable<Cliente> , IIncludableQueryable<Cliente,object>> includes,
//         int page,
//         int pageSize,
//         string orderBy,
//         bool ascending,
//         bool disableTracking = true
//     );
// }