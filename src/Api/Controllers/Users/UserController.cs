using Application.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDTO>> GetUserById([FromRoute] Guid id)
    {
        return Ok(await Task.FromResult(new GetUserDTO
        {
            Email = "eduardocaldas.dev@gmail.com",
            Name = "Eduardo Caldas"
        }));
    }
}
