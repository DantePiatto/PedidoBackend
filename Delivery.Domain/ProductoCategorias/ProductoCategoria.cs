

using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Productos;

namespace Delivery.Domain.ProductoCategorias;

public sealed class ProductoCategoria : Entity<ProductoCategoriaId>
{

    public ProductoCategoria() { }

    public ProductoCategoria(

        ProductoCategoriaId id,
        ProductoId productoId,
        ParametroId categoriaId
    ) : base(id)

    {

        ProductoId = productoId;
        CategoriaId = categoriaId;

    }

    public ProductoId? ProductoId { get; set; }

    public ParametroId? CategoriaId { get; set; }

    public Producto? Producto { get; set; }

    public Parametro? Categoria { get; set; }

    public static ProductoCategoria Create(

        ProductoCategoriaId id,
        ProductoId productoId,
        ParametroId categoriaId

    )
    {
        var productoCategoria = new ProductoCategoria(id, productoId, categoriaId);

        return productoCategoria;
    }




}