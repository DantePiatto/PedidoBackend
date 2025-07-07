
namespace Delivery.Domain.EstadoPedidos;

public interface IEstadoPedidoRepository
{
    void Add(EstadoPedido estadoPedido);
    void Update(EstadoPedido estadoPedido);
}