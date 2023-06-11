using System.Reflection.Metadata.Ecma335;
using Application.UseCases.Users;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints.Users;

public class UserEndpoints : IEndpointGroup
{
    public void Register(WebApplication app)
    {
        var userEndpointGroup = app.MapGroup("/user");

        userEndpointGroup.MapGet("{id}", async (IGetUserByIdUC getUserByIdUC, Guid id, CancellationToken cancellationToken) =>
        {
            var result = await getUserByIdUC.Execute(id, cancellationToken);
            return result.Match(
                succ => Results.Ok(succ),
                fail => Results.NotFound(fail.Message));
        });
    }
}
