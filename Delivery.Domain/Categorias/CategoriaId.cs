
namespace Delivery.Domain.Categorias;

public record CategoriaId(Guid Value)
{
    public static CategoriaId New() => new(Guid.NewGuid());
}