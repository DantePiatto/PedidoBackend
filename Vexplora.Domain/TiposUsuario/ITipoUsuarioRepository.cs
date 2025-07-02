namespace Vexplora.Domain.TipoUsuarios;

public interface ITipoUsuarioRepository
{
    void Add(TipoUsuario tipoUsuario);

    void Update(TipoUsuario tipoUsuario);
    
    void Delete(TipoUsuario tipoUsuario);

    Task<TipoUsuario?> GetByIdAsync(TipoUsuarioId id, CancellationToken cancellationToken = default);
    
    Task<List<TipoUsuario>> GetAll(CancellationToken cancellationToken = default);
}