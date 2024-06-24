using AOS.Shared.DTO.DomainsAndGoals;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class CreateDomainRequest : BaseRequest
{
    public required DomainDTO Domain { get; set; }
}
