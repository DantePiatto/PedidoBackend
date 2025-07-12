
using Delivery.Domain.Parametros;
using Delivery.Domain.Productos;

namespace Delivery.Domain.ProductoCategorias;

public class ProductoCategoriasDto
{
    public string? Id { get; set; }

    public string? ProductoId { get; set; }

    public string? CategoriaId { get; set; }


    public ProductoDto? Producto { get; set; }

    public ParametroDto? Categoria { get; set; }



}