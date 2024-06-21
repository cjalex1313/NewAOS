using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AOS.DataAccess;
using AOS.BusinessLogic.Services;

namespace AOS.BusinessLogic;

public static class BusinessLogicModuleExtension
{
    public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddScoped<IDomainService, DomainService>();
    }
}
