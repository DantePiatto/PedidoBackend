

namespace Delivery.Domain.Opiniones;

public record OpinionId(Guid Value)
{

    public static OpinionId New() => new(Guid.NewGuid());
}