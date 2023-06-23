using Application.Requests.Users;
using Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

public class UserEndpointGroup : IEndpointGroup
{
    public void Register(IEndpointRouteBuilder app)
    {
        var userEndpointGroup = app.MapGroup("/user");

        userEndpointGroup.MapGet("{id}", Get);
        userEndpointGroup.MapPost("", Post);
        userEndpointGroup.MapDelete("{id:Guid}", Delete);
    }

    private async Task<IResult> Get(IGetUserByIdUC getUserByIdUC, Guid id, CancellationToken cancellationToken)
    {
        return Results.Ok(await getUserByIdUC.Execute(id, cancellationToken));
    }

    private async Task<IResult> Post(ICreateUserUC createUserUC, CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await createUserUC.Execute(request, cancellationToken);
        return Results.Created($"/users/{user.Id}", user);
    }

    private async Task<IResult> Delete(
        [FromServices] IDeleteUserUC deleteUserUC,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await deleteUserUC.Execute(id, cancellationToken);
        return Results.NoContent();
    }
}
