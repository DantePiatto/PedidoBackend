

using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Categorias;

public static class CategoriaErrors
{

    public static Error NotFound = new(

        404, "No existe la categoria buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "categoria ya existe en la base de datos"
    );
    


}