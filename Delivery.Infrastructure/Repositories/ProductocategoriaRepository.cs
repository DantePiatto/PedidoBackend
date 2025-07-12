



using Delivery.Application.Paginations;
using Delivery.Domain.ProductoCategorias;
using Delivery.Domain.Productos;
using Microsoft.EntityFrameworkCore;


namespace Delivery.Infrastructure.Repositories;

internal sealed class ProductoCategoriaRepository : Repository<ProductoCategoria, ProductoCategoriaId>, IProductoCategoriaRepository
{

    public ProductoCategoriaRepository(ApplicationDbContext dbContext) : base(dbContext)

    {

    }

}