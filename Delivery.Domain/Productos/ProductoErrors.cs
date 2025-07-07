
using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Productos;

public static class ProductoErrors
{

    public static Error NotFound = new(

        404, "No existe el producto buscado con ese Id"



    );

    public static Error AlreadyExists = new(


        400,"Producto ya existe en la base de datos"
    );


}