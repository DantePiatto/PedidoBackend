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
        var url = $"https://graph.facebook.com/me?fields=email,first_name,middle_name,last_name,picture&access_token={token}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<JsonElement>(json);

        var firstName = "";
        var middleName = "";
        string pictureUrl = "";

        try
        {
            firstName = data.TryGetProperty("first_name", out var firstNameProp) ? firstNameProp.GetString() ?? "" : "";
            middleName = data.TryGetProperty("middle_name", out var middleNameProp) && !string.IsNullOrWhiteSpace(middleNameProp.GetString())
                        ? middleNameProp.GetString() : "" ?? "";
            pictureUrl = data.TryGetProperty("picture", out var pictureProp) &&
                        pictureProp.TryGetProperty("data", out var pictureDataProp) &&
                        pictureDataProp.TryGetProperty("url", out var urlProp)
                            ? urlProp.GetString() ?? "" : "";
        }
        catch (System.Exception)
        {            
            throw;
        }

        return new OAuthUserInfo
        {
            Email = data.TryGetProperty("email", out var emailProp) ? emailProp.GetString() ?? "" : "",
            Nombre = !string.IsNullOrWhiteSpace(middleName) ? firstName + " " + middleName : firstName,
            Apellidos = data.TryGetProperty("last_name", out var lastNameProp) ? lastNameProp.GetString() ?? "" : "",
            PictureUrl = pictureUrl
        };
/*
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
*/        
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
