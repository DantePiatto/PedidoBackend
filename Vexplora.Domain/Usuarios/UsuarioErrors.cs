


using Vexplora.Domain.Abstractions;

namespace Vexplora.Domain.Usuarios;


public static class UsuarioErrors
{
    public static readonly Error NotFound = new(
        404,
        "No existe el usuario buscado por este id"
    );

    public static readonly Error CredencialesInvalidas = new(
        401,
        "Las credenciales son invalidas"
    );

    public static readonly Error AlreadyExists = new(
        400,
        "El usuario ya existe en la base de datos"
    );

    public static Error AlreadyExistsDni = new(
        400,
        "Ya se encuentra un usuario registrado con ese Dni"
    );

    public static readonly Error NotFoundEmail = new(
        404,
        "El correo no se encuentra validado. Por favor verifique el correo en su red social, e inténtelo nuevamente."
    );
}
