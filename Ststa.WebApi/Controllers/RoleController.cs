using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ststa.Infrastructure.RoleRepository.GetAllRole;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseController
{
    [Authorize(Policy = "FromAssistant")]
    [HttpGet("GetAllRole/{userId}")]
    public async Task<ActionResult<List<GetAllRoleResponse>>> GetAll(int userId)
    {
        var request = new GetAllRoleReqest { UserId = userId };
        return await Mediator.Send(request);
    }

}
