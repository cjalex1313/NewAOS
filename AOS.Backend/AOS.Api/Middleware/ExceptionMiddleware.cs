using AOS.Api.ViewModels;
using AOS.Shared.Exceptions;
using System.Net;
using System.Text.Json;

namespace AOS.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        if (exception is BaseException)
        {
            var baseEx = (BaseException)exception;
            context.Response.StatusCode = baseEx.StatusCode;
            var response = new BaseResponse()
            {
                Succeeded = false,
                Error = baseEx.ErrorMessage,
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        else
        {
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));
        }
    }
}
