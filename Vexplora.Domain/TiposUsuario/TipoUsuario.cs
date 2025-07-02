using Vexplora.Domain.Abstractions;

namespace Vexplora.Domain.TipoUsuarios;

public sealed class TipoUsuario : Entity<TipoUsuarioId>
{
    private TipoUsuario() { }

    private TipoUsuario(
        TipoUsuarioId id,
        string nombre
    ) : base(id)
    {
        Nombre = nombre;
    }

    public string? Nombre { get; private set; }
   
    public static TipoUsuario Create(
        TipoUsuarioId id,
        string nombre
    )
    {
        var tipoUsuario = new TipoUsuario(id, nombre);

        return tipoUsuario;
    }

    public Result Update(
        string nombre
    )
    {
        Nombre = nombre.Length > 0 ? nombre : Nombre;

        return Result.Success();
    }

}