using AOS.DataAccess;
using AOS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.BusinessLogic.Services;
public interface IDomainService
{
    IEnumerable<Domain> GetDomains();
}

public class DomainService : IDomainService
{
    private readonly AOSDbContext _dbContext;

    public DomainService(AOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Domain> GetDomains()
    {
        return _dbContext.Domains.AsNoTracking().ToList();
    }
}
