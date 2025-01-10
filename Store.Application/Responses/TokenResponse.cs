using System.Xml;

namespace Store.Application.Responses;
public class TokenResponse
{
    public required string AccessToken { get; set; }
    public required DateTime ExpiresIn { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpiresIn { get; set; }

}
