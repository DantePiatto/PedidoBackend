

using Delivery.Domain.Categorias;
using Delivery.Domain.Pagos;


namespace Delivery.Infrastructure.Repositories;

internal sealed class PagoRepository : Repository<Pago, PagoId>, IPagoRepository
{

    public PagoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}