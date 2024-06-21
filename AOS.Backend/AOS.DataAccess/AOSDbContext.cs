using AOS.DataAccess.DbMappings;
using AOS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace AOS.DataAccess;

public class AOSDbContext : DbContext
{
    public DbSet<Domain> Domains { get; set; }

    private readonly IUserContextService _userContextService;

    public AOSDbContext(DbContextOptions<AOSDbContext> options, IUserContextService userContextService) : base(options)
    {
        _userContextService = userContextService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DomainMapping.MapDomain(modelBuilder.Entity<Domain>());
    }

    public override int SaveChanges()
    {
        var now = DateTime.UtcNow;

        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = now;
                        entity.ModifiedDate = now;
                        entity.CreatedBy = _userContextService.UserId;
                        entity.ModifiedBy = _userContextService.UserId;
                        break;
                    case EntityState.Modified:
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        entity.ModifiedDate = now;
                        entity.ModifiedBy = _userContextService.UserId;
                        break;
                }
            }
        }

        return base.SaveChanges();
    }
}
