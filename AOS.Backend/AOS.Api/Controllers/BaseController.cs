using AOS.Shared.Exceptions.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AOS.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected string GetUserId()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return userIdString ?? "system";
    }
}
