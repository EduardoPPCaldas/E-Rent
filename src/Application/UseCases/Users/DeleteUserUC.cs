using System.Net;
using Application.Repositories;
using Application.Responses;
using Application.Shared;
using Domain.Users;

namespace Application.UseCases.Users;

[GenerateAutomaticInterface]
public class DeleteUserUC : IDeleteUserUC
{
    private readonly IGenericRepository<User> _repo;

    public DeleteUserUC(IGenericRepository<User> repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid id, CancellationToken cancellationToken)
    {
        var wasDeleted = await _repo.Delete(id, cancellationToken);
        if(!wasDeleted)
        {
            throw new ErrorResponseException
            {
                Error = $"Could not find any user with this id: {id}",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
