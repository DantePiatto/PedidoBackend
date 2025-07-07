

using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Roles;
using Delivery.Domain.Usuarios;

namespace Delivery.Domain.UsuarioRoles;

public sealed class UsuarioRol : Entity<UsuarioRolId>
{
    public UsuarioRol() { }

    public UsuarioRol(

        UsuarioRolId id,
        UsuarioId usuarioId,
        RolId rolId

    )
    {
        UsuarioId = usuarioId;
        RolId = rolId;
    }

    public UsuarioId? UsuarioId { get; set; }

    public RolId? RolId { get; set; }

    public Usuario? Usuario { get; set; }

    public Rol? Rol { get; set; }

    public static UsuarioRol Create(

        UsuarioRolId id,
        UsuarioId usuarioId,
        RolId rolId
    )
    {
        var usuarioRol = new UsuarioRol(id, usuarioId, rolId);
        return usuarioRol;
    }
    

}