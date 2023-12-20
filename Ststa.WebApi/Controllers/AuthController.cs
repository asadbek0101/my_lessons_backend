using Microsoft.AspNetCore.Mvc;
using Ststa.Infrastructure.AuthRepository.LoginUser;
using Ststa.Infrastructure.AuthRepository.RegisterUser;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("Register")]
    public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserRequest request)
    {
        return await Mediator.Send(request);
    }
}
