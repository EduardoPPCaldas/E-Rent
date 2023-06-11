using Application.Repositories;
using Application.Responses.Users;
using Application.Shared;
using Application.UseCases.Users.Exceptions;
using Domain.Users;
using LanguageExt.Common;

namespace Application.UseCases.Users;

[GenerateAutomaticInterface]
public class GetUserByIdUC : IGetUserByIdUC
{
    private readonly IGenericRepository<User> _userRepository;

    public GetUserByIdUC(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserResponse>> Execute(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(id, cancellationToken);

        if (user is null)
            return new Result<GetUserResponse>(new UserNotFoundException($"Could not found any user with this id: {id}"));

        return new Result<GetUserResponse>(new GetUserResponse
        {
            Email = user.Email,
            Name = user.Name,
            Id = user.Id
        });
    }
}
