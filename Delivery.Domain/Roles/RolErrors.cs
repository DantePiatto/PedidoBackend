


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Roles;

public static class RolErrors
{

    public static Error NotFound = new(

        404, "No existe el rol buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Rol ya existe en la base de datos"
    );
    


}