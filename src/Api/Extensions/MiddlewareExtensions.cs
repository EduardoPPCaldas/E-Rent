using Api.Middlewares;

namespace Api.Extensions;

public static class MiddlewareExtensions
{
    public static void RegisterMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ExceptionMiddleware>();
    }
}
