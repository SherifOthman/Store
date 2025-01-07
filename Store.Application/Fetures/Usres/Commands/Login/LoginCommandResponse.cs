using System.Xml;

namespace Store.Application.Fetures.Usres.Commands.Login;
public class LoginCommandResponse
{
    public required string AccessToken { get; set; }
    public required DateTime ExpiresIn { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpiresIn { get; set; }

}
