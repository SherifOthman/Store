using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Domain.Common;
using Store.Domain.Entities.Users;


namespace Store.Dal.Context;

public class AppDbContext : DbContext
{
    //  private readonly ILoggedInService _loggedInService;

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    //public AppDbContext(DbContextOptions options, ILoggedInService loggedInService)
    //    : base(options)
    //{
    //    _loggedInService = loggedInService;
    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //foreach (var entry in ChangeTracker.Entries<TrackedEntity>())
        //{
        //    switch (entry.State)
        //    {
        //        case EntityState.Added:
        //            entry.Entity.CreatedByUserId = _loggedInService!.UserId;
        //            break;

        //        case EntityState.Modified:
        //            entry.Entity.LastModifiedOn = DateTime.UtcNow;
        //            entry.Entity.LastModifiedByUserId = _loggedInService?.UserId;
        //            break;
        //    }
        //}

        return base.SaveChangesAsync(cancellationToken);
    }

}
