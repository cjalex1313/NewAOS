using AOS.Shared.DTO.DomainsAndGoals;
using AOS.Shared.Entities;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class CreateDomainResponse : BaseResponse
{
    public DomainDTO Domain { get; set; }

    public CreateDomainResponse(Domain domain)
    {
        Domain = new DomainDTO
        {
            Id = domain.Id,
            Name = domain.Name,
            Description = domain.Description,
            Deleted = domain.Deleted,
            Draft = domain.Draft,
        };

        Succeeded = true;
        Error = null;
    }
}
