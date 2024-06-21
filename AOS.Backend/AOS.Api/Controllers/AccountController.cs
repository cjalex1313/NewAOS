using AABC.IdentityServer.Client;
using AOS.Api.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AOS.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IIdentityServerClient _identityServerClient;
    public AccountController(IIdentityServerClient identityServerClient)
    {
        _identityServerClient = identityServerClient;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("connect")]

    public async Task<IActionResult> Connect([FromBody] LoginRequest request)
    {
        var response = await _identityServerClient.Connect.Token(request.Username, request.Password);
        if (!response.Success)
        {
            throw new Exception(string.Join("|", response.Errors));
        }
        if (response == null) return StatusCode(500);
        if (!string.IsNullOrWhiteSpace(response.Data.Error))
        {
            return Unauthorized();
        }
        return Ok(response.Data);
    }
}
