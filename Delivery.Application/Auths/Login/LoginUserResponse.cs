
using Delivery.Domain.Usuarios;

namespace Delivery.Application.Auths.Login;

public class LoginUserResponse
{
    public string? Token { get; set; }

    public UsuarioDto? Usuario { get; set; }

    public static LoginUserResponse Create(string token, UsuarioDto usuario )
    {
        return new LoginUserResponse{
            Token = token,
            Usuario = usuario,
        };
    }


}
