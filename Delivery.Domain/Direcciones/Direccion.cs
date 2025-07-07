
using Delivery.Domain.Abstractions;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Usuarios;

namespace Delivery.Domain.Direcciones;

public sealed class Direccion : Entity<DireccionId>
{
    public Direccion() { }

    public Direccion(

        DireccionId id,
        UsuarioId usuarioId,
        string direccion,
        string referencia,
        double latitud,
        double altitud,
        bool predeterminada


    ) : base(id)
    {
        UsuarioId = usuarioId;
        Direc = direccion;
        Referencia = referencia;
        Latitud = latitud;
        Altitud = altitud;
        Predeterminado = predeterminada;


    }

    public UsuarioId? UsuarioId { get; set; }
    public string? Direc { get; set; }

    public string? Referencia { get; set; }
    public double? Latitud { get; set; }
    public double? Altitud { get; set; }

    public bool Predeterminado { get; set; }

    public Usuario? Usuario { get; set; }

    public List<Pedido>?Pedido { get; set; }

    public static Direccion Create(

        DireccionId id,
        UsuarioId usuarioId,
        string direccion,
        string referencia,
        double latitud,
        double altitud,
        bool predeterminada

    )
    {
        var direc = new Direccion(id, usuarioId, direccion, referencia, latitud, altitud, predeterminada);

        return direc;
    }


    public Result Update(

        UsuarioId usuarioId,
        string direccion,
        string referencia,
        double latitud,
        double altitud,
        bool predeterminada

    )
    {
        UsuarioId = usuarioId;
        Direc = direccion.Length > 0 ? direccion : Direc;
        Referencia = referencia.Length > 0 ? referencia : Referencia;
        Latitud = latitud > 0 ? latitud : Latitud;
        Altitud = altitud > 0 ? altitud : Altitud;

        return Result.Success();
        
    }
    



}