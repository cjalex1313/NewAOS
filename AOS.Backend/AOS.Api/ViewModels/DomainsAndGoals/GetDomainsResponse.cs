using AOS.Shared.DTO.DomainsAndGoals;
using AOS.Shared.Entities;

namespace AOS.Api.ViewModels.DomainsAndGoals;

public class GetDomainsResponse : BaseResponse
{
    public List<DomainDTO> Domains { get; set; }

    public GetDomainsResponse(IEnumerable<Domain> domains)
    {
        Succeeded = true;
        Error = null;
        if (domains != null)
        {
            Domains = domains.Select(d =>
            {
                return new DomainDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Deleted = d.Deleted,
                    Draft = d.Draft,
                };
            }).ToList();
        } else
        {
            Domains = new List<DomainDTO>();
        }
    }
}
