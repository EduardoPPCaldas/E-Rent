using System.Reflection.Metadata.Ecma335;
using Application.DTOs.Users;
using Application.Repositories;
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

    public async Task<Result<GetUserDTO>> Execute(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(id, cancellationToken);
        if (user is null)
        {
            return new Result<GetUserDTO>(new UserNotFoundException($"User with id {id} not found"));
        }

        return new Result<GetUserDTO>(new GetUserDTO
        {
            Email = user.Email,
            Name = user.Name,
            Id = user.Id
        });
    }
}
