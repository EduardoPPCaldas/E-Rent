using Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesInjectionExtension
{
    public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
    {
        // Users
        services
            .AddScoped<IGetUserByIdUC, GetUserByIdUC>();

        return services;
    }
}
