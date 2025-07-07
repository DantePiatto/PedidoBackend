


using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Pagos;

public static class PagoErrors
{

    public static Error NotFound = new(

        404, "No existe el pago buscada por esa Id"

    );

    public static Error AlreadyExists = new(

        400, "Pago ya existe en la base de datos"
    );
    


}