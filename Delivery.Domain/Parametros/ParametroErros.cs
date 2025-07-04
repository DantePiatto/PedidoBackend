using Delivery.Domain.Abstractions;

namespace Delivery.Domain.Parametros;

public static class ParametroErrors
{
    public static Error ParametroExists = new Error(409,"Este parametro ya existe, cree uno nuevo");
    public static Error ParametroNotFound = new Error(404,"Este parametro no existe");
    public static Error DependenciaNotFound = new Error(404,"Este parametro dependencia no existe");
    public static Error ValorExists = new Error(404,"Este valor ya existe en este subnivel");
    public static Error ParametroInUse = new Error(404,"Parametro esta en uso no puede eliminarlo.");
}