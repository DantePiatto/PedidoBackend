

namespace Delivery.Domain.Repartidores;


public record RepartidorId(Guid Value)
{

    public static RepartidorId New() => new(Guid.NewGuid());
}