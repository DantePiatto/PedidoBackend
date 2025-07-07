

namespace Delivery.Domain.PedidoAsignados;

public record PedidoAsignadoId(Guid Value)
{

    public static PedidoAsignadoId New() => new(Guid.NewGuid());
}