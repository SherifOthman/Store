
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Infrastructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    public JwtProvider(IOptionsMonitor<JwtOptions> options)
    {
        _options = options.CurrentValue;
    }

    public string GenerateAccessToken(User user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),

        };

        var signingCreadentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
          issuer: _options.Issuer,
          audience: _options.Audience,
          claims: claims,
          expires: DateTime.UtcNow.AddHours(_options.DurationInHours),
          signingCredentials: signingCreadentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public string RenewAccessToken(string RefreshToken)
    {
        throw new NotImplementedException();
    }
}
