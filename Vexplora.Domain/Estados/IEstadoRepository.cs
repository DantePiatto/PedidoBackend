namespace Vexplora.Domain.Estados;

public interface IEstadoRepository
{
    void Add(Estado estado);

    void Update(Estado estado);
    
    void Delete(Estado estado);

    Task<Estado?> GetByIdAsync(EstadoId id, CancellationToken cancellationToken = default);
    
    Task<List<Estado>> GetAll(CancellationToken cancellationToken = default);
}