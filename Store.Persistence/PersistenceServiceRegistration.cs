
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;

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
                sqlOptions=> sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
