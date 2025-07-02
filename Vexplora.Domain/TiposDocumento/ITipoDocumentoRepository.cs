namespace Vexplora.Domain.TipoDocumentos;

public interface ITipoDocumentoRepository
{
    void Add(TipoDocumento tipoDocumento);

    void Update(TipoDocumento tipoDocumento);
    
    void Delete(TipoDocumento tipoDocumento);

    Task<TipoDocumento?> GetByIdAsync(TipoDocumentoId id, CancellationToken cancellationToken = default);
    
    Task<List<TipoDocumento>> GetAll(CancellationToken cancellationToken = default);
}