using Microsoft.EntityFrameworkCore;
using Vexplora.Domain.Estados;

namespace Vexplora.Infrastructure.Repositories;

internal sealed class EstadoRepository : Repository<Estado, EstadoId>, IEstadoRepository
{
    public EstadoRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<List<Estado>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Estado>()
                        .ToListAsync();
    }
}