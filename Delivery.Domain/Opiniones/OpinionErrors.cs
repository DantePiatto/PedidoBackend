


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Opiniones;

public static class OpinionErrors
{

    public static Error NotFound = new(

        404, "No existe la opinion buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Opinion ya existe en la base de datos"
    );
    


}