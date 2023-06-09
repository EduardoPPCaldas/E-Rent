using Application.Repositories;
using Application.Requests.Users;
using Application.Responses.Users;
using Application.Shared;
using Domain.Users;

namespace Application.UseCases.Users;

[GenerateAutomaticInterface]
public class CreateUserUC : ICreateUserUC
{
    private readonly IGenericRepository<User> _repository;

    public CreateUserUC(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userCreated = await _repository.Add(new User
        {
            Email = request.Email,
            Name = request.Name,
            LastName = request.LastName,
            Password = request.Password
        }, cancellationToken);

        return new CreateUserResponse
        {
            Email = userCreated.Email,
            Name = userCreated.Name,
            Id = userCreated.Id
        };
    }
}
