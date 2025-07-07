


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.PedidoAsignados;

public static class PedidoAsignadoErrors
{

    public static Error NotFound = new(

        404, "No existe el pedido asignado buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Pedido Asignado ya existe en la base de datos"
    );
    


}