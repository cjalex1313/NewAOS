using AOS.Shared.Entities;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class UpdateDomainResponse : CreateDomainResponse
{
    public UpdateDomainResponse(Domain domain) : base(domain) { }
}
