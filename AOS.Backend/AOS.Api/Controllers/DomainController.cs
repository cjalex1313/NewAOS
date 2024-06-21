using AOS.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DomainController : BaseController
{
    private readonly IDomainService _domainService;

    public DomainController(IDomainService domainService)
    {
        _domainService = domainService;
    }

    [HttpGet]
    [Authorize]
    public ActionResult GetDomains()
    {
        var domains = _domainService.GetDomains();
        return Ok(domains);
    }
}
