using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ststa.Infrastructure.UserRepository.CreateUser;
using Ststa.Infrastructure.UserRepository.GetAllUser;
using Ststa.Infrastructure.UserRepository.GetOneUser;
using Ststa.Infrastructure.UserRepository.UpdateUser;
using Ststa.WebApi.Exceptions;
using Ststa.Infrastructure.UserRepository.DeleteUser;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
   // [Authorize(Policy = "FromAssistant")]
    [HttpGet("GetAllUser")]
    public async Task<PaginatorApiResponse> Get([FromQuery] GetAllUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [Authorize(Policy = "FromAssistant")]
    [HttpGet("GetOneUser")]
    public async Task<ActionResult<GetOneUserResponse>> GetOne([FromQuery] GetOneUserRequest request)
    {
        return await Mediator.Send(request);
    }

    //[Authorize(Policy = "FromAssistant")]
    [HttpPost("CreateUser")]
    public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("UpdateUser")]
    public async Task<UpdateUserResponse> Update([FromBody] UpdateUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("DeleteUsers")]
    public async Task<ApiResponse> Update([FromBody] DeleteUserRequest request)
    {
        return await Mediator.Send(request);
    }
}
