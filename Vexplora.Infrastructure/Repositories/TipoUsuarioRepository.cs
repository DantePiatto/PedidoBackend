using Microsoft.EntityFrameworkCore;
using Vexplora.Domain.TipoUsuarios;

namespace Vexplora.Infrastructure.Repositories;

internal sealed class TipoUsuarioRepository : Repository<TipoUsuario, TipoUsuarioId>, ITipoUsuarioRepository
{
    public TipoUsuarioRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<List<TipoUsuario>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TipoUsuario>()
                        .ToListAsync();
    }
}