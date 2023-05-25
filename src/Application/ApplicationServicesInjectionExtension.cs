namespace Application;

public static class ApplicationServicesInjectionExtension
{
    public static IServiceProvider InjectApplicationServices(this IServiceProvider services)
    {
        return services;
    }
}
