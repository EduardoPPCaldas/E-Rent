using Application.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDIExtension
{
    public static IServiceCollection InjectInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ApplicationDatabase>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SQLServer"),
            b => b.MigrationsAssembly(typeof(ApplicationDatabase).Assembly.FullName));
        });

        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
