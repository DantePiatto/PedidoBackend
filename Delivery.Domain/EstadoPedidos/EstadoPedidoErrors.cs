



using Delivery.Domain.Abstractions;

namespace Delivery.Domain.EstadoPedidos;

public static class EstadoPedidoErrors
{

    public static Error NotFound = new(

        404, "No existe el estado pedido buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Estado Pedido ya existe en la base de datos"
    );
    


}