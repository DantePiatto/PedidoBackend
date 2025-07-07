

using System.Diagnostics;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Categorias;
using Delivery.Domain.DetallePedidos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Domain.Productos;

public sealed class Producto : Entity<ProductoId>


{

    public Producto() { }

    public Producto(

        ProductoId id,
        RestauranteId restauranteId,
        CategoriaId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagen_url
        //bool activo
    ) : base(id)
    {
        RestauranteId = restauranteId;
        CategoriaId = categoriaId;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Imagen_Url = imagen_url;
        //Activos = activo;

    }

    public RestauranteId? RestauranteId { get; set; }
    public CategoriaId? CategoriaId { get; set; }
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public double? Precio { get; set; }

    public string? Imagen_Url { get; set; }

    //public bool Activos { get; set; }


    public Categoria? Categoria  { get; set; }

    public Restaurante? Restaurante { get; set; }
    
    public List<DetallePedido>? DetallePedidos { get; set; }


    public static Producto Create(

        ProductoId id,
        RestauranteId restauranteId,
        CategoriaId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagen_url
    //bool activo
    )
    {

        var restaurante = new Producto(id, restauranteId, categoriaId, nombre, descripcion, precio, imagen_url);

        return restaurante;
    }

    public Result Update(


        RestauranteId restauranteId,
        CategoriaId categoriaId,
        string nombre,
        string descripcion,
        double precio,
        string imagen_url

    )
    {
        RestauranteId = restauranteId;
        CategoriaId = categoriaId;
        Nombre = nombre.Length > 0 ? nombre : Nombre;
        Descripcion = descripcion.Length > 0 ? descripcion : Descripcion;
        Precio = precio > 0 ? precio : Precio;
        Imagen_Url = imagen_url.Length > 0 ? imagen_url : Imagen_Url;


        return Result.Success();
    }

    



}

