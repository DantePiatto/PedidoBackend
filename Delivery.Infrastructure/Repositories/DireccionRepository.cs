

using Delivery.Domain.Categorias;
using Delivery.Domain.Direcciones;


namespace Delivery.Infrastructure.Repositories;

internal sealed class DireccionRepository : Repository<Direccion, DireccionId>, IDireccionRepository
{

    public DireccionRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}