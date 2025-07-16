using HRIS.Core.Users.Commands;
using HRIS.Shared.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("Login")]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto dto) => await SendRequestAsync(new LoginUserCommand(dto));
}