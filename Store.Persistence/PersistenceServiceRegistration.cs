using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Abstractions.Repositories;
using Store.Persistence.Repositories;


namespace Store.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            // options.ConfigureWarnings(cfg => cfg.Ignore(RelationalEventId.PendingModelChangesWarning));
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRefreshTokenRpository, RefreshTokenRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
 

        return services;
    }
}
