

namespace Delivery.Domain.DetallePedidos;

public interface IDetallePedidoRepository
{
    void Add(DetallePedido detallePedido);
    void Update(DetallePedido detallePedido);
    
}