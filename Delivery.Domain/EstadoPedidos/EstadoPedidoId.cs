

namespace Delivery.Domain.EstadoPedidos;


public record EstadoPedidoId(Guid Value)
{
    public static EstadoPedidoId New() => new (Guid.NewGuid());
}