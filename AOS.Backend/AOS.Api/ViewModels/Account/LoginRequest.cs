namespace AOS.Api.ViewModels.Account;

public class LoginRequest : BaseRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
