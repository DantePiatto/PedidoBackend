
using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Direcciones;

public static class DireccionErrors
{

    public static Error NotFound = new(

        404, "No existe la direccion buscado con ese Id"



    );

    public static Error AlreadyExists = new(


        400,"Direccion ya existe en la base de datos"
    );


}