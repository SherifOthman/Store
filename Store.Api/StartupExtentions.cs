using Store.Api.Middlewares;
using Store.Api.OptionsSetup;
using Store.Api.Services;
using Store.Application;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Infrastructure;
using Store.Persistence;

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

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.ConfigureOptions<ScalarOptionsSetup>();

        return services;
    }

}
