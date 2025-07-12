

using Delivery.Application.Paginations;
using Delivery.Domain.Restaurantes;
using Microsoft.EntityFrameworkCore;


namespace Delivery.Infrastructure.Repositories;

internal sealed class RestauranteRepository : Repository<Restaurante, RestauranteId>, IRestauranteRepository, IPaginationRestauranteRepository
{

    public RestauranteRepository(ApplicationDbContext dbContext) : base(dbContext)

    {

    }


    public async Task<List<Restaurante>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Restaurante>().ToListAsync(cancellationToken);
    }


    public async Task<Restaurante?> GetByIdRestauranteAsync(RestauranteId id, CancellationToken cancellationToken = default)
    {

        return await DbContext.Set<Restaurante>().Where(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);

    }

    public async Task<bool> NombreExists(string nombre, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Restaurante>().AnyAsync(r => r.Nombre == nombre, cancellationToken);
    }
    
    
    

}