namespace Delivery.Domain.Abstractions;


public record Error(int Code, string Name)
{

    public static Error None = new(200, string.Empty);
    public static Error NullValue = new(400, "Un valor Null fue ingresado");
    public static Error BadRequest = new(400, "");
    public static Error NotFound = new(400, "No se encontro el valor buscado");
    public static Error InternalServerError = new(500, "Hay un error interno en el servidor");

}