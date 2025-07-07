
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;


namespace Delivery.Domain.Restaurantes;

public sealed class Restaurante : Entity<RestauranteId>
{

    public Restaurante() { }

    public Restaurante(

        Restaurante id,
        string nombre,
        string descripcion,
        string logoUrl,
        int tiempoEntrega
    )
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

        Restaurante id,
        string nombre,
        string descripcion,
        string logoUrl,
        int tiempoEntrega

    )
    {
        var restaurante = new Restaurante(id, nombre, descripcion, logoUrl, tiempoEntrega);

        return restaurante;
    }


}