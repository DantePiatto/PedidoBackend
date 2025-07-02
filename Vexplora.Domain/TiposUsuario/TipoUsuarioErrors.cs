using Vexplora.Domain.Abstractions;

namespace Sigen.Domain.TipoUsuarios;

public static class TipoUsuarioErrors
{
    public static readonly Error NotFound = new(
        404,
        "No existe el tipo usuario buscada por este id"
    );

    public static readonly Error AlreadyExists = new(
        400,
        "El tipo usuario ya existe en la base de datos"
    );
}