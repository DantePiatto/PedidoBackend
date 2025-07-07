

using Delivery.Domain.Categorias;
using Delivery.Domain.Pedidos;


namespace Delivery.Infrastructure.Repositories;

internal sealed class PedidoRepository : Repository<Pedido, PedidoId>, IPedidoRepository
{

    public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}