

using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;

namespace Delivery.Domain.Categorias;

public sealed class Categoria : Entity<CategoriaId>
{

    private Categoria() { }

    private Categoria(

        CategoriaId id,
        string nombre


    ) : base(id)
    {

        Nombre = nombre;

    }

    public string? Nombre { get; set; }

    public List<Producto>? Productos  { get; set; }




    public static Categoria Create(

        CategoriaId id,
        string nombre

    )
    {
        var categoria = new Categoria(id, nombre);

        return categoria;
    }


    public Result Update(

        string nombre
    )
    {
        Nombre = nombre.Length > 0 ? nombre : Nombre;

        return Result.Success();
    }



}