

using Delivery.Domain.EstadoPedidos;


namespace Delivery.Infrastructure.Repositories;

internal sealed class EstadoPedidoRepository : Repository<EstadoPedido, EstadoPedidoId>, IEstadoPedidoRepository
{

    public EstadoPedidoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}