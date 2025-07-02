

namespace Delivery.Application.Abstractions.Authentication;

public interface IOAuth2Validator
{
    Task<OAuthUserInfo?> ValidateAsync(string provider, string token);
}