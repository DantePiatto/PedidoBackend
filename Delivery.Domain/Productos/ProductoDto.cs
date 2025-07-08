
using Delivery.Domain.Parametros;
using Delivery.Domain.Restaurantes;

namespace Delivery.Domain.Productos;

public class ProductoDto

{

    public string? Id { get; set; }

    public string? RestauranteId { get; set; }
    public string? CategoriaId { get; set; }

    public RestauranteDto? Restaurante { get; set; }

    public ParametroDto? Categoria { get; set; }

    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public double? Precio { get; set; }

    public string ? ImagenUrl { get; set; }
    
    public bool Activo { get; set; }




}

   

