
namespace Delivery.Domain.ProductoCategorias;

public record ProductoCategoriaId(Guid Value)
{
    public static ProductoCategoriaId New() => new(Guid.NewGuid());
}