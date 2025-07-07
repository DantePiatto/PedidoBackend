

using Delivery.Domain.PedidoAsignados;


namespace Delivery.Infrastructure.Repositories;

internal sealed class PedidoAsignadoRepository : Repository<PedidoAsignado, PedidoAsignadoId>, IPedidoAsignadoRepository
{

    public PedidoAsignadoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}