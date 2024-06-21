namespace AOS.Api.ViewModels;

public class BaseResponse
{
    public bool Succeeded { get; set; } = true;
    public string? Error { get; set; } = null;
}
