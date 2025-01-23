using System.Xml;

namespace Store.Application.Responses;
public class TokenResponse
{
    public required string AccessToken { get; set; }
    public long ExpiresIn { get; set; }
    public required string RefreshToken { get; set; }
    public long RefreshTokenExpiresIn { get; set; }
}
