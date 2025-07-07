
using Delivery.Domain.Categorias;


namespace Delivery.Infrastructure.Repositories;

internal sealed class CategoriaRepository : Repository<Categoria, CategoriaId>, ICategoriaRepository
{

    public CategoriaRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}