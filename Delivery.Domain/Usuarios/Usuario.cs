

using Delivery.Domain.Abstractions;
using Delivery.Domain.Direcciones;
using Delivery.Domain.Opiniones;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Repartidores;
using Delivery.Domain.UsuarioRoles;

namespace Delivery.Domain.Usuarios;

public sealed class Usuario : Entity<UsuarioId>
{
    private Usuario() { }

    private Usuario(
        UsuarioId id,
        string correo,
        string password,
        bool isDefaultPassword,
        string nombres,
        string apellidos,
        string? dni,
        string? celular,
        string sexo,
        // RolId rolId
        bool isCelularVerificado,
        bool isEmailVerificado
    ) : base(id)
    {

        Correo = correo;
        Password = password;
        IsDefaultPassword = isDefaultPassword;
        Nombres = nombres;
        Apellidos = apellidos;
        Dni = dni;
        Celular = celular;
        Sexo = sexo;
        // RolId = rolId;
        IsCelularVerificado = isCelularVerificado;
        IsEmailVerificado = isEmailVerificado;
    }

    public string? Correo { get; set; }
    public string? Password { get; set; }
    public string? Nombres {get; set;}
    public string? Apellidos {get; set;}
    public string? Dni {get; set;}    
    public string? Celular {get; set;}    
    public string? Sexo { get; private set; }
    public bool IsDefaultPassword { get; set; }

    public bool IsCelularVerificado { get; set; }

    public bool IsEmailVerificado { get; set; }
    
    public List<Direccion>? Direccion { get; set; }

    public List<Pedido>?Pedido { get; set; }

     public Repartidor?Repartidor { get; set; }

     public List<Opinion>?Opinion { get; set;}
     public List<UsuarioRol>?usuarioRols { get; set;}
    
    // public RolId? RolId { get; set; }
    // public Rol? Rol { get; set; }
    // public Cliente? Cliente { get; set; }
    // public Empleado? Empleado { get; set; }

    public static Usuario Create(
        UsuarioId id,
        string correo,
        string password,
        bool isDefaultPassword,
        string nombres,
        string apellidos,
        string? dni,
        string? celular,
        string sexo,
        bool isCelularVerificado,
        bool isEmailVerificado
    // RolId rolId
    )
    {
        var usuario = new Usuario(id, correo, password, isDefaultPassword, nombres, apellidos, dni, celular, sexo,isCelularVerificado,isEmailVerificado);

        return usuario;
    }

    public Result Update(
        string correo,
        string nombres,
        string apellidos,
        string? dni,
        string? celular
        // string sexo,
    )
    {
        Correo = correo.Length > 0 ? correo : Correo;
        Nombres = nombres.Length > 0 ? nombres : Nombres;   
        Apellidos = apellidos.Length > 0 ? apellidos : Apellidos; 
        Dni = dni; 
        Celular = celular; 
        // Sexo = sexo.Length > 0 ? sexo : Sexo;
        // RolId = rolId;
        
        return Result.Success();
    }

}