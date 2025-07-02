using Vexplora.Domain.Abstractions;

namespace Sigen.Domain.TipoDocumentos;

public static class TipoDocumentoErrors
{
    public static readonly Error NotFound = new(
        404,
        "No existe el tipo documento buscada por este id"
    );

    public static readonly Error AlreadyExists = new(
        400,
        "El tipo documento ya existe en la base de datos"
    );
}