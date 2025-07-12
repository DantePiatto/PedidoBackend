


namespace Delivery.Domain.Usuarios;

public class UsuarioDto
{
    public string? Id { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Celular { get; set; }
    public string? Sexo { get; set; }
    public bool IsDefaultPassword { get; set; }
    public string? Correo { get; set; }

    public bool IsCelularVerificado { get; set; }

    public bool IsEmailVerificado { get; set; }
    


    // public int RolId { get;  set; }
}