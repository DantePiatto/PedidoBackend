using Vexplora.Domain.Abstractions;

namespace Vexplora.Domain.Estados;

public sealed class Estado : Entity<EstadoId>
{
    private Estado() { }

    private Estado(
        EstadoId id,
        string nombre,
        string tabla
    ) : base(id)
    {
        Nombre = nombre;
        Tabla = tabla;
    }

    public string? Nombre { get; private set; }
    public string? Tabla { get; private set; }

    public static Estado Create(
        EstadoId id,
        string nombre,
        string tabla
    )
    {
        var estado = new Estado(id, nombre, tabla);

        return estado;
    }

    public Result Update(
        string nombre,
        string tabla
    )
    {
        Nombre = nombre.Length > 0 ? nombre : Nombre;
        Tabla = tabla.Length > 0 ? tabla : Tabla;

        return Result.Success();
    }

}