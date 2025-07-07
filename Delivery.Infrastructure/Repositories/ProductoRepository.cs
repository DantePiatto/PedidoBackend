

using Delivery.Domain.Productos;


namespace Delivery.Infrastructure.Repositories;

internal sealed class ProductoRepository : Repository<Producto, ProductoId>, IProductoRepository
{

    public ProductoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}