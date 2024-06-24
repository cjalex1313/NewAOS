using AOS.Shared.DTO.DomainsAndGoals;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class UpdateDomainRequest : BaseRequest
{
    public required DomainDTO Domain { get; set; }
}
