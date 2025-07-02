using Vexplora.Domain.Abstractions;

namespace Sigen.Domain.Estados;

public static class EstadoErrors
{
    public static readonly Error NotFound = new(
        404,
        "No existe el tipo estado buscada por este id"
    );

    public static readonly Error AlreadyExists = new(
        400,
        "El tipo estado ya existe en la base de datos"
    );
}