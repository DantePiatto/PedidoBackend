

namespace Vexplora.Domain.Usuarios;

public interface IUsuarioRepository
{

    Task<Usuario?> GetByIdAsync(UsuarioId id, CancellationToken cancellationToken = default);

    void Add(Usuario usuario);

    void Update(Usuario usuario);
    
    void Delete(Usuario usuario);

     Task<Usuario?> GetByIdUserIncludes(UsuarioId id, CancellationToken cancellationToken = default);
     Task<Usuario?> GetByEmailAsync(string correo, CancellationToken cancellationToken = default);
    
    Task<bool> UsuarioExists(string dniUsuario, CancellationToken cancellationToken = default);
    

}