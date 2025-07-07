


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.UsuarioRoles;

public static class UsuarioRolErrors
{

    public static Error NotFound = new(

        404, "No existe el rol de usuario buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Rol de Usuario ya existe en la base de datos"
    );
    


}