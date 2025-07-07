
namespace Delivery.Domain.Roles;

public record RolId(Guid Value)
{
    public static RolId New() => new(Guid.NewGuid());
}