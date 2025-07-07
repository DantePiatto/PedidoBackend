

using Delivery.Domain.Categorias;
using Delivery.Domain.Repartidores;


namespace Delivery.Infrastructure.Repositories;

internal sealed class RepartidorRepository : Repository<Repartidor, RepartidorId>, IRepartidorRepository
{

    public RepartidorRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}