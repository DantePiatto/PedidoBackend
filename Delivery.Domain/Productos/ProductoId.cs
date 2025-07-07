
namespace Delivery.Domain.Productos;

public record ProductoId(Guid Value)
{

    public static ProductoId New() => new(Guid.NewGuid());
}

