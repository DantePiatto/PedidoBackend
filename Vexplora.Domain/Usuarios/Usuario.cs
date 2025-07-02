using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Estados;
using Vexplora.Domain.TipoDocumentos;
using Vexplora.Domain.TipoUsuarios;

namespace Vexplora.Domain.Usuarios;

public sealed class Usuario : Entity<UsuarioId>
{
    private Usuario() { }

    private Usuario(
        UsuarioId id,
        TipoUsuarioId tipoUsuarioId,
        EstadoId estadoId,
        TipoDocumentoId tipoDocumentoId,
        string username,
        string clave,
        string nombre,
        string apellido,
        string nroDocumento,
        bool recibeNotificaciones,
        DateTime fechaCreacion,
        string rutaDocumento
    ) : base(id)
    {
        Id = id;
        TipoUsuarioId = tipoUsuarioId;
        EstadoId = estadoId;
        TipoDocumentoId = tipoDocumentoId;
        Username = username;
        Clave = clave;
        Nombre = nombre;
        Apellido = apellido;
        NroDocumento = nroDocumento;
        RecibeNotificaciones = recibeNotificaciones;
        FechaCreacion = fechaCreacion;
        RutaDocumento = rutaDocumento;
    }

    public TipoUsuarioId? TipoUsuarioId { get; private set; }
    public TipoUsuario? TipoUsuario { get; private set; }
    public EstadoId? EstadoId { get; private set; }
    public Estado? Estado { get; private set; }
    public TipoDocumentoId? TipoDocumentoId { get; private set; }
    public TipoDocumento? TipoDocumento { get; private set; }
    public string? Username { get; private set; }
    public string? Clave { get; set; }
    public string? Nombre {get; set;}
    public string? Apellido {get; set;}
    public string? Email { get; set; }
    public string? NroDocumento {get; set;}    
    public bool RecibeNotificaciones { get; set; }
    public DateTime? FechaCreacion { get; private set; }
    public string? RutaDocumento {get; set;}    

    public static Usuario Create(
        UsuarioId id,
        TipoUsuarioId tipoUsuarioId,
        EstadoId estadoId,
        TipoDocumentoId tipoDocumentoId,
        string username,
        string clave,
        string nombre,
        string apellido,
        string nroDocumento,
        bool recibeNotificaciones,
        DateTime fechaCreacion,
        string rutaDocumento
    )
    {
        var usuario = new Usuario(id, tipoUsuarioId, estadoId, tipoDocumentoId, username, clave, nombre, apellido, nroDocumento, recibeNotificaciones, fechaCreacion, rutaDocumento);

        return usuario;
    }

    public Result Update(
        TipoUsuarioId tipoUsuarioId,
        EstadoId estadoId,
        TipoDocumentoId tipoDocumentoId,
        string username,
        string nombre,
        string apellido,
        string nroDocumento,
        bool recibeNotificaciones,
        string rutaDocumento
    )
    {
        TipoUsuarioId = tipoUsuarioId;
        EstadoId = estadoId;
        TipoDocumentoId = tipoDocumentoId;
        Username = username;
        Nombre = nombre;
        Apellido = apellido;
        NroDocumento = nroDocumento;
        RecibeNotificaciones = recibeNotificaciones;
        RutaDocumento = rutaDocumento;
        
        return Result.Success();
    }

}