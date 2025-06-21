
using Microsoft.EntityFrameworkCore;
using Delivery.Domain.Usuarios;

namespace Delivery.Infrastructure.Repositories;

internal sealed class UsuarioRepository : Repository<Usuario, UsuarioId>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Usuario?> GetByIdUserIncludes(UsuarioId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Usuario>()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<Usuario?> GetByEmailAsync(string correo, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Usuario>()
                    .Where(u => u.Correo == correo)
                    .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> UsuarioExists(string dni, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Usuario>().AnyAsync(u => u.Dni == dni, cancellationToken);
    }    
}