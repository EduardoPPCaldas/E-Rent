using Application.Requests.Users;
using Application.UseCases.Users;

namespace Api.Endpoints.Users;

public class UserEndpointGroup : IEndpointGroup
{
    public void Register(WebApplication app)
    {
        var userEndpointGroup = app.MapGroup("/user");

        userEndpointGroup.MapGet("{id}", Get);
        userEndpointGroup.MapPost("", Post);
    }

    private async Task<IResult> Get(IGetUserByIdUC getUserByIdUC, Guid id, CancellationToken cancellationToken)
    {
        var result = await getUserByIdUC.Execute(id, cancellationToken);
        return result.Match(
            succ => Results.Ok(succ),
            fail => Results.NotFound(fail.Message));
    }

    private async Task<IResult> Post(ICreateUserUC createUserUC, CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await createUserUC.Execute(request, cancellationToken);
        return result.Match(
            succ => Results.Created($"user/{succ.Id}",succ),
            fail => Results.BadRequest(fail.Message)
        );
    }
}
