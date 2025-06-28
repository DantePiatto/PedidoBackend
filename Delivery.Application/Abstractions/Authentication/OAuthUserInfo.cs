namespace Delivery.Application.Abstractions.Authentication;


public class OAuthUserInfo
{
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;

}