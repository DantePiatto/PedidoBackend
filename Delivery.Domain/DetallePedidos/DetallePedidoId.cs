

namespace Delivery.Domain.DetallePedidos;

public record DetallePedidoId(Guid Value)
{
    public static DetallePedidoId New() => new(Guid.NewGuid());
}