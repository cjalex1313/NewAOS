using AOS.DataAccess;
using System.Security.Claims;

namespace AOS.Api.Middleware;

public class UserIdMiddleware
{
    private readonly RequestDelegate _next;

    public UserIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserContextService userContextService)
    {
        if (context?.User?.Identity?.IsAuthenticated == true)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                userContextService.UserId = userId;
                userContextService.IsAuthenticated = true;
            }
        }
        if (context != null)
        {
            await _next(context);
        }
    }
}
