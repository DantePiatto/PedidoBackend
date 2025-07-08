

using System.Diagnostics;
using Delivery.Domain.Abstractions;
using Delivery.Domain.DetallePedidos;
using Delivery.Domain.Parametros;
using Delivery.Domain.ProductoCategorias;
using Delivery.Domain.Restaurantes;

namespace Delivery.Domain.Productos;

public sealed class Producto : Entity<ProductoId>


{

    public Producto() { }

    public Producto(

        ProductoId id,
        RestauranteId restauranteId,
        ParametroId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagenUrl
        //bool activo
    ) : base(id)
    {
        RestauranteId = restauranteId;
        CategoriaId = categoriaId;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        ImagenUrl = imagenUrl;
        //Activos = activo;

    }

    public RestauranteId? RestauranteId { get; set; }
    public ParametroId? CategoriaId { get; set; }
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public double? Precio { get; set; }

    public string? ImagenUrl { get; set; }

    //public bool Activos { get; set; }


    public Parametro? Categoria  { get; set; }

    public Restaurante? Restaurante { get; set; }

    public List<ProductoCategoria>? ProductoCategoria { get; set; }
    
    public List<DetallePedido>? DetallePedidos { get; set; }
    
    


    public static Producto Create(

        ProductoId id,
        RestauranteId restauranteId,
        ParametroId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagenUrl
    //bool activo
    )
    {

        var restaurante = new Producto(id, restauranteId, categoriaId, nombre, descripcion, precio, imagenUrl);

        return restaurante;
    }

    public Result Update(


        
        ParametroId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagen_url

    )
    {
    
        CategoriaId = categoriaId;
        Nombre = nombre.Length > 0 ? nombre : Nombre;
        Descripcion = descripcion.Length > 0 ? descripcion : Descripcion;
        Precio = precio > 0 ? precio : Precio;
        ImagenUrl = imagen_url.Length > 0 ? imagen_url : ImagenUrl;


        return Result.Success();
    }

    



}

