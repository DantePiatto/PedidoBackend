
namespace Delivery.Domain.Pedidos;

public interface IPedidoRepository
{
    void Add(Pedido pedido);
    void Update(Pedido pedido);
} 