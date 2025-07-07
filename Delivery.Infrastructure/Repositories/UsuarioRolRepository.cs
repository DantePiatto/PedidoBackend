

using Delivery.Domain.Categorias;
using Delivery.Domain.UsuarioRoles;


namespace Delivery.Infrastructure.Repositories;

internal sealed class UsuarioRolRepository : Repository<UsuarioRol, UsuarioRolId>, IUsuarioRolRepository
{

    public UsuarioRolRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}