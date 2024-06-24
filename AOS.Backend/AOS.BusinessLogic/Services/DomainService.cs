using AOS.DataAccess;
using AOS.Shared.DTO.DomainsAndGoals;
using AOS.Shared.Entities;
using AOS.Shared.Exceptions.DomainsAndGoals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.BusinessLogic.Services;
public interface IDomainService
{
    Domain AddDomain(DomainDTO domain);
    Domain DeleteDomain(int id);
    IEnumerable<Domain> GetDomains();
    Domain UpdateDomain(int id, DomainDTO domain);
}

public class DomainService : IDomainService
{
    private readonly AOSDbContext _dbContext;

    public DomainService(AOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Domain AddDomain(DomainDTO domain)
    {
        var domainEntity = new Shared.Entities.Domain()
        {
            Name = domain.Name,
            Description = domain.Description,
            Deleted = domain.Deleted,
            Draft = domain.Draft,
        };
        _dbContext.Domains.Add(domainEntity);
        _dbContext.SaveChanges();
        return domainEntity;
    }

    public Domain DeleteDomain(int id)
    {
        var dbDomain = _dbContext.Domains.FirstOrDefault(x => x.Id == id);
        if (dbDomain == null)
        {
            throw new DomainNotFoundException(id);
        }
        dbDomain.Deleted = true;
        _dbContext.SaveChanges();
        return dbDomain;
    }

    public IEnumerable<Domain> GetDomains()
    {
        return _dbContext.Domains.AsNoTracking().ToList();
    }

    public Domain UpdateDomain(int id, DomainDTO domain)
    {
        var dbDomain = _dbContext.Domains.FirstOrDefault(d => d.Id == id);
        if (dbDomain == null)
        {
            throw new DomainNotFoundException(id);
        }
        dbDomain.Name = domain.Name;
        dbDomain.Description = domain.Description;
        dbDomain.Draft = domain.Draft;
        _dbContext.SaveChanges();
        return dbDomain;
    }
}
