using Microsoft.EntityFrameworkCore;
using Vexplora.Domain.TipoDocumentos;

namespace Vexplora.Infrastructure.Repositories;

internal sealed class TipoDocumentoRepository : Repository<TipoDocumento, TipoDocumentoId>, ITipoDocumentoRepository
{
    public TipoDocumentoRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<List<TipoDocumento>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TipoDocumento>()
                        .ToListAsync();
    }
}