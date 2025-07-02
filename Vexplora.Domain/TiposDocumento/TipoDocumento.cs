using Vexplora.Domain.Abstractions;

namespace Vexplora.Domain.TipoDocumentos;

public sealed class TipoDocumento : Entity<TipoDocumentoId>
{
    private TipoDocumento() { }

    private TipoDocumento(
        TipoDocumentoId id,
        string nombre
    ) : base(id)
    {
        Nombre = nombre;
    }

    public string? Nombre { get; private set; }
   
    public static TipoDocumento Create(
        TipoDocumentoId id,
        string nombre
    )
    {
        var tipoDocumento = new TipoDocumento(id, nombre);

        return tipoDocumento;
    }

    public Result Update(
        string nombre
    )
    {
        Nombre = nombre.Length > 0 ? nombre : Nombre;

        return Result.Success();
    }

}