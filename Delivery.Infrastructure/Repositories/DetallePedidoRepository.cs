

using Delivery.Domain.DetallePedidos;


namespace Delivery.Infrastructure.Repositories;

internal sealed class DetallepedidoRepository : Repository<DetallePedido, DetallePedidoId>, IDetallePedidoRepository
{

    public DetallepedidoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}