using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesInjectionExtension
{
    public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
