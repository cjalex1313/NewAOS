using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.Shared.Exceptions.DomainsAndGoals;
public class DomainNotFoundException : BaseException
{
    public DomainNotFoundException(int domainId)
    {
        this.ErrorMessage = $"Domain with id {domainId} not found";
        this.StatusCode = 404;
    }
}
