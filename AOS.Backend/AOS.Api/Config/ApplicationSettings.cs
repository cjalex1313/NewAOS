using AABC.IdentityServer.Client;

namespace AOS.Api.Config;

public class ApplicationSettings
{
    public required IdentityServerClientConfiguration IdentityServer { get; set; }
}
