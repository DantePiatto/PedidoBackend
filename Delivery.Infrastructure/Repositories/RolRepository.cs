

using Delivery.Domain.Categorias;
using Delivery.Domain.Roles;


namespace Delivery.Infrastructure.Repositories;

internal sealed class RolRepository : Repository<Rol, RolId>, IRolRepository
{

    public RolRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}