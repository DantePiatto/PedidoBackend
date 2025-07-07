

using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Repartidores;

public static class RepartidorErrors
{

    public static Error NotFound = new(

        404, "No existe el repartidor buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Repartidor ya existe en la base de datos"
    );
    


}