using Api.Endpoints;
using Api.Endpoints.Users;

namespace Api.Extensions;

public static class RegisterEndpointGroupsExtension
{
    public static WebApplication RegisterEndpointGroups(this WebApplication app)
    {
        foreach(var endpointGroup in app.Services.GetServices<IEndpointGroup>())
        {
            if (endpointGroup is null) throw new InvalidProgramException("Endpoint not found");

            endpointGroup.Register(app);
        }

        return app;
    }

    public static IServiceCollection RegisterEndpointsServices(this IServiceCollection services)
    {
        services.AddTransient<IEndpointGroup, UserEndpointGroup>();

        return services;
    }
}
