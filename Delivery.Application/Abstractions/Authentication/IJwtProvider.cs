
using Delivery.Domain.Usuarios;

namespace Delivery.Application.Abstractions.Authentication;

public interface IJwtProvider 
{
    Task<string> Generate(Usuario user);

    DateTime GetExpirationTime(string token);

    Dictionary<string, string> ExtractClaims(string token);
    string GetEmailFromToken(string token);
    string GetUserIdFromToken(string token);

}