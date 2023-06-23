using System.Net;
using Application.Repositories;
using Application.Responses;
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
        var user = await _userRepository.GetById(id, cancellationToken) ?? throw new ErrorResponseException
            {
                Error = $"Could not find any user with this id: {id}",
                HttpStatusCode = HttpStatusCode.NotFound
            };

        return new Result<GetUserResponse>(new GetUserResponse
        {
            Email = user.Email,
            Name = user.Name,
            Id = user.Id
        });
    }
}
