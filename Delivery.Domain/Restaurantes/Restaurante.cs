
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Shared;


namespace Delivery.Domain.Restaurantes;

public sealed class Restaurante : Entity<RestauranteId>
{

    public Restaurante() { }

    public Restaurante(

        RestauranteId id,
        string nombre,
        string descripcion,
        string logoUrl,
        int tiempoEntrega
    ) : base(id)
    {

        Nombre = nombre;
        Descripcion = descripcion;
        LogoUrl = logoUrl;
        TiempoEntrega = tiempoEntrega;


    }


    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
    public string? LogoUrl { get; set; }

    public int? TiempoEntrega { get; set; }

    public List<Producto>? Producto { get; set; }

    public static Restaurante Create(

        RestauranteId id,
        string nombre,
        string descripcion,
        string logoUrl,
        int tiempoEntrega

    )
    {
        var restaurante = new Restaurante(id, nombre, descripcion, logoUrl, tiempoEntrega);

        return restaurante;
    }


    public Result Update(

        string nombre,
        string descripcion,
        string logoUrl,
        int tiempoEntrega,
        bool activo

    )
    {
        Nombre = nombre.Length > 0 ? nombre : Nombre;
        Descripcion = descripcion.Length > 0 ? descripcion : Descripcion;
        LogoUrl = logoUrl.Length > 0 ? logoUrl : LogoUrl;
        TiempoEntrega = tiempoEntrega > 0 ? tiempoEntrega : TiempoEntrega;
        Activo = new Activo(activo);

        return Result.Success();
    }


}