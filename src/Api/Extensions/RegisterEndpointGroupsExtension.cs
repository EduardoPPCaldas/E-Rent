using Api.Endpoints;

namespace Api.Extensions;

public static class RegisterEndpointGroupsExtension
{
    public static WebApplication RegisterEndpointGroups(this WebApplication app)
    {
        var endpointGroups = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointGroup)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointGroup>();

        foreach(var endpointGroup in endpointGroups)
        {
            if (endpointGroup is null) throw new InvalidProgramException("Endpoint not found");

            endpointGroup.Register(app);
        }

        return app;
    }
}
