

using Delivery.Domain.Abstractions;

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
        string sexo
        // RolId rolId
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
    }

    public string? Correo { get; set; }
    public string? Password { get; set; }
    public string? Nombres {get; set;}
    public string? Apellidos {get; set;}
    public string? Dni {get; set;}    
    public string? Celular {get; set;}    
    public string? Sexo { get; private set; }
    public bool IsDefaultPassword { get; set; }
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
        string sexo
        // RolId rolId
    )
    {
        var usuario = new Usuario(id, correo, password, isDefaultPassword, nombres, apellidos, dni, celular, sexo);

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