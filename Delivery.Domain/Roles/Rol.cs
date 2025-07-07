

using Delivery.Domain.Abstractions;
using Delivery.Domain.UsuarioRoles;

namespace Delivery.Domain.Roles;


public sealed class Rol : Entity<RolId>
{
    public Rol() { }

    public Rol(

        RolId id,
        string nombre
    ) : base(id)
    {
        Nombre = nombre;
    }

    public string? Nombre { get; set; }

    public List<UsuarioRol>? UsuarioRols { get; set; }

    public static Rol Create(
        RolId id,
        string nombre
    )
    {
        var rol = new Rol(id, nombre);

        return rol;
    }
    


}