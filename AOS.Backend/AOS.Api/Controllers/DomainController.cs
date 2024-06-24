using AOS.Api.ViewModels.DomainsAndGoals;
using AOS.BusinessLogic.Services;
using AOS.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOS.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class DomainController : BaseController
{
    private readonly IDomainService _domainService;

    public DomainController(IDomainService domainService)
    {
        _domainService = domainService;
    }

    [HttpGet]
    public ActionResult<GetDomainsResponse> GetDomains()
    {
        var domains = _domainService.GetDomains();
        var response = new GetDomainsResponse(domains);
        return Ok(response);
    }

    [HttpPost]
    public ActionResult<CreateDomainResponse> CreateDomain([FromBody] CreateDomainRequest request)
    {
        Domain domain = _domainService.AddDomain(request.Domain);
        var response = new CreateDomainResponse(domain);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateDomainResponse> UpdateDomain([FromRoute] int id, [FromBody] UpdateDomainRequest request)
    {
        Domain domain = _domainService.UpdateDomain(id, request.Domain);
        var response = new UpdateDomainResponse(domain);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<DeleteDomainResponse> DeleteDomain([FromRoute] int id)
    { 
        Domain domain = _domainService.DeleteDomain(id);
        var response = new DeleteDomainResponse(domain);
        return Ok(response);
    }
}
