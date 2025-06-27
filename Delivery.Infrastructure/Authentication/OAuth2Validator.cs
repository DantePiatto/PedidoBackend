using System.Text.Json;
using Delivery.Application.Abstractions.Authentication;
using Google.Apis.Auth;


namespace Delivery.Infrastructure.Authentication;

public class OAuth2Validator : IOAuth2Validator
{

    private readonly HttpClient _http;

    public OAuth2Validator(HttpClient http)
    {
        _http = http;
    }
    public async Task<OAuthUserInfo?> ValidateAsync(string provider, string token)
    {

        switch (provider.ToLower())
        {
            case "facebook":
                return await ValidateFacebookToken(token);
            case "google":
                return await ValidateGoogleToken(token);
            // case "instagram": return await ValidateInstagramToken(token);
            default:
                return null;
        }


        // if (provider.Equals("google", StringComparison.CurrentCultureIgnoreCase))
        // {
        //     var payload = await GoogleJsonWebSignature.ValidateAsync(token);

        //     return new OAuthUserInfo
        //     {

        //         Email = payload.Email,
        //         Nombre = payload.GivenName,
        //         Apellidos = payload.FamilyName,
        //         PictureUrl = payload.Picture

        //     };
        // }
        // else if (provider.Equals("facebook", StringComparison.CurrentCultureIgnoreCase))
        // {
        //     var payload =
        // }

        // Puedes agregar lógica para Facebook/Instagram aquí
        // return null;
    }


    private async Task<OAuthUserInfo?> ValidateFacebookToken(string token)
    {
        var url = $"https://graph.facebook.com/me?fields=email&access_token={token}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<JsonElement>(json);

        return new OAuthUserInfo
        {
            // Id = data.GetProperty("id").GetString() ?? "",
            // Name = data.GetProperty("name").GetString() ?? "",
            // Email = data.TryGetProperty("email", out var emailProp) ? emailProp.GetString() ?? "" : ""
        };
    }

    private async Task<OAuthUserInfo?> ValidateGoogleToken(string token)
    {
        var url = $"https://oauth2.googleapis.com/tokeninfo?id_token={token}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<JsonElement>(json);

        return new OAuthUserInfo
        {
                //         Email = data.Email,
                // Nombre = payload.GivenName,
                // Apellidos = payload.FamilyName,
                // PictureUrl = payload.Picture
        };
    }
}
