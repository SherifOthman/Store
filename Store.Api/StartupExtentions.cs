using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Store.Api.BackgroundTasks;
using Store.Api.Middlewares;
using Store.Api.OptionsSetup;
using Store.Api.Services;
using Store.Application;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Infrastructure;
using Store.Infrastructure.Authentication;
using Store.Persistence;
using System.Text;

namespace Store.Api;

public static class StartupExtentions
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add dffirenet layers services
        services.AddApplicationServiceRegistration();
        services.AddPersistenceServiceRegistration(configuration);
        services.AddInfrastructureServices();

        // Add web api services
        services.AddHttpContextAccessor();
        services.AddScoped<ILoggedInService, LoggedInService>();
        services.AddHostedService<RefreshTokensCleanerTask>();

        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<ScalarOptionsSetup>();


        // Add Authentication
        services.AddJwtBearerAuthentication(configuration);


        return services;
    }

    public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure JWT Bearer Authentication
        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
                };
            });

        return services;
    }

}
