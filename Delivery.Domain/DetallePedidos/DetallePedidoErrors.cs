


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.DetallePedidos;

public static class DetallePedidoErrors
{

    public static Error NotFound = new(

        404, "No existe el detallePedido buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "categoria ya existe en la base de datos"
    );
    


}