using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.TotalFeature.GetAllTotal;
using Ststa.WebApi.Exceptions;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllTotalRequst request)
    {
        return await Mediator.Send(request);
    }
}
