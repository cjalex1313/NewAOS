using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.DataAccess;
public static class DataAccessModuleExtension
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AOSDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ATrackAdmin"));
        });
        services.AddScoped<IUserContextService, UserContextService>();
    }
}
