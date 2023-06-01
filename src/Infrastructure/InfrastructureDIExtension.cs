using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDIExtension
{
    public static IServiceCollection InjectInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ApplicationDatabase>(opt => opt.UseSqlServer(configuration.GetConnectionString("SQLServer")));

        return services;
    }
}
