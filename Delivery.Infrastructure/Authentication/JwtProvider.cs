
using System.Security.Claims;
using System.Text;
using Delivery.Application.Abstractions.Authentication;
using Delivery.Domain.Usuarios;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly IUsuarioRepository _usuarioRepository;
    // private readonly IUserTenantRepository _userTenantRepository;

    public JwtProvider(
        IOptions<JwtOptions> options,
        IUsuarioRepository usuarioRepository
        // IUserTenantRepository userTenantRepository
        )
    {
        _options = options.Value;
        _usuarioRepository = usuarioRepository;
        // _userTenantRepository = userTenantRepository;
    }

    public async Task<string> Generate(Usuario user)
    {
        var userFounded = await _usuarioRepository.GetByIdUserIncludes(user.Id!);

        var claims = new List<Claim> {
            new(CustomClaims.Email,user.Correo!),
            new(CustomClaims.UserId, user.Id!.Value.ToString()),
            // new(CustomClaims.Rol,user.RolId!.Value.ToString()),
            // new(ClaimTypes.Role, user.RolId!.Value.ToString()) 
        };

        var sigingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey!)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddDays(365),
            sigingCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    public DateTime GetExpirationTime(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.ValidTo;
    }

    public Dictionary<string, string> ExtractClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);

        return claims;
    }

    public string GetEmailFromToken(string token)
    {
        var claims = ExtractClaims(token);
        string email = claims.GetValueOrDefault(CustomClaims.Email, "");

        return email;

    }

    public string GetUserIdFromToken(string token)
    {
        var claims = ExtractClaims(token);
        string userId = claims.GetValueOrDefault(CustomClaims.UserId, "");

        return userId;

    }
}