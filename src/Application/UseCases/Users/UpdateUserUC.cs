using System.Net;
using Application.Repositories;
using Application.Requests.Users;
using Application.Responses;
using Application.Responses.Users;
using Application.Shared;
using Domain.Users;

namespace Application.UseCases.Users;

[GenerateAutomaticInterface]
public class UpdateUserUC : IUpdateUserUC
{
    private readonly IGenericRepository<User> _repo;

    public UpdateUserUC(IGenericRepository<User> repo)
    {
        _repo = repo;
    }

    public async Task<UpdateUserResponse> Execute(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _repo.GetById(id, cancellationToken) ?? throw new ErrorResponseException
        {
            Error = $"Could not found any user with this id: {id}",
            HttpStatusCode = HttpStatusCode.NotFound
        };
        user.Email = request.Email;
        await _repo.Update(user, id, cancellationToken);
        return new UpdateUserResponse
        {
            Email = user.Email,
            Name = user.Name,
            Id = user.Id
        };
    }
}
