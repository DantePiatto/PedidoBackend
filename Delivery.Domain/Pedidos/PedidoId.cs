

namespace Delivery.Domain.Pedidos;


public record PedidoId(Guid Value)
{
    public static PedidoId New() => new(Guid.NewGuid());
}