

using Delivery.Application.Paginations;
using Delivery.Domain.Productos;
using Microsoft.EntityFrameworkCore;


namespace Delivery.Infrastructure.Repositories;

internal sealed class ProductoRepository : Repository<Producto, ProductoId>, IProductoRepository,IPaginationProductoRepository
{

    public ProductoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {

    }

    public async Task<List<Producto>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Producto>().Include(p=>p.Restaurante).Include(p=>p.Categoria).ToListAsync(cancellationToken);
    }

    public async Task<Producto?> GetByIdProductoAsync(ProductoId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Producto>().Include(p => p.Restaurante).Include(p=>p.Categoria)
        .Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
    }



    
    public async Task<bool> NombreExists(string nombre, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Producto>().AnyAsync(r => r.Nombre == nombre, cancellationToken);
    }
    

}