

using Delivery.Domain.Abstractions;

namespace Delivery.Domain.ProductoCategorias;

public static class ProductoCategoriaErrors
{

    public static Error NotFound = new(

        404, "No existe el producto categoria buscado con ese Id"



    );

    public static Error AlreadyExists = new(


        400,"Producto Categoria ya existe en la base de datos"
    );


}