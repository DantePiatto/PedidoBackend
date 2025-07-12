


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Restaurantes;

public static class RestauranteErrors
{

    public static Error NotFound = new(

        404, "No existe el restaurante buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Restaurante ya existe en la base de datos"
    );

    public static Error PaginationFailed(string detail) =>
        new(500, $"Error al paginar restaurantes: {detail}");

    
    


}