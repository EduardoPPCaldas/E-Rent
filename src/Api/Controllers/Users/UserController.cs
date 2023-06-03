using Application.DTOs.Users;
using Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IGetUserByIdUC _getUserByIdUC;

    public UserController(IGetUserByIdUC getUserByIdUC)
    {
        _getUserByIdUC = getUserByIdUC;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDTO>> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _getUserByIdUC.Execute(id, cancellationToken);

        return result.Match<ActionResult<GetUserDTO>>(
            usr => Ok(usr),
            err => NotFound(err.Message)
        );
    }
}
