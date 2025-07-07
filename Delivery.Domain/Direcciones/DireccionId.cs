

namespace Delivery.Domain.Direcciones;

public record DireccionId(Guid Value)
{

    public static DireccionId New() => new(Guid.NewGuid());
}