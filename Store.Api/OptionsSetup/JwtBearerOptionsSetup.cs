using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.Infrastructure.Authentication;
using System.Text;

namespace Store.Api.OptionsSetup;

public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        Console.WriteLine($"Issuer: {_jwtOptions.Issuer}");
        Console.WriteLine($"Audience: {_jwtOptions.Audience}");
        Console.WriteLine($"SecurityKey: {_jwtOptions.SecurityKey}");

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey))
        };
    }
}
