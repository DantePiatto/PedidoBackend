
namespace Delivery.Domain.Restaurantes;


public class RestauranteDto
{

    public string? Id { get; set; }

    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }

    public string? LogoUrl { get; set; }

    public int? TiempoEntrega { get; set; }

    public bool Activo { get; set; }
    
    
}