
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Models;
using Store.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Store.Infrastructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    public JwtProvider(IOptionsMonitor<JwtOptions> options)
    {
        _options = options.CurrentValue;
    }

    public TokenVm GenerateAccessToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey)),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            Subject = new ClaimsIdentity(getUserClaims(user)),
            Expires = DateTime.UtcNow.AddHours(_options.TokenLifeTime),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(securityToken);

        return new TokenVm
        {
            Token = accessToken,
            ExpiresIn = tokenDescriptor.Expires.Value
        };
    }

    public TokenVm GenerateRefreshToken()
    {

        var randomBytes = RandomNumberGenerator.GetBytes(128);

        var token = Convert.ToBase64String(randomBytes)
             .Replace('+', '-')
             .Replace('/', '_')
             .Replace("=", "");

        return new TokenVm
        {
            Token = token,
            ExpiresIn = DateTime.UtcNow.AddDays(_options.RefreshTokenLifeTime)
        };
    }

    private List<Claim> getUserClaims(User user)
    {
        var userRoles = user.Roles.Select(u => u.Name);

        var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        foreach (var role in userRoles)
        {
            userClaims.Add(new(ClaimTypes.Role, role));
        }

        return userClaims;
    }
}