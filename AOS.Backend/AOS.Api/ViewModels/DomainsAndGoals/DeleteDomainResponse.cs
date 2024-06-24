using AOS.Shared.Entities;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class DeleteDomainResponse : CreateDomainResponse
{
    public DeleteDomainResponse(Domain domain) : base(domain) { }
}