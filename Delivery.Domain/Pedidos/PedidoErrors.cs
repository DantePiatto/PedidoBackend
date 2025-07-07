


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Pedidos;

public static class PedidooErrors
{

    public static Error NotFound = new(

        404, "No existe el pedido buscado con ese Id"



    );

    public static Error AlreadyExists = new(


        400,"Pedido ya existe en la base de datos"
    );


}