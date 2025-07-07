

using Delivery.Domain.Categorias;
using Delivery.Domain.Restaurantes;


namespace Delivery.Infrastructure.Repositories;

internal sealed class RestauranteRepository : Repository<Restaurante, RestauranteId>, IRestauranteRepository
{

    public RestauranteRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}