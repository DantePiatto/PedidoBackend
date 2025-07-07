namespace Delivery.Domain.UsuarioRoles;

public record UsuarioRolId(Guid Value)
{
    public static UsuarioRolId New() => new(Guid.NewGuid());
}