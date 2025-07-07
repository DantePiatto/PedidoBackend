

namespace Delivery.Domain.Restaurantes;

public record RestauranteId(Guid Value)
{
    public static RestauranteId New() => new(Guid.NewGuid());
}