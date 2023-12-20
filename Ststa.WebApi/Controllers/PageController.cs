using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.PageFeature.CreatePage;
using Ststa.Application.Features.PageFeature.GetOnePage;
using Ststa.WebApi.Exceptions;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PageController : BaseController
{
    [HttpGet("GetOnePage")]
    public async Task<ApiResponse> GetOne([FromQuery] GetOnePageRequest request)
    {
        return await Mediator.Send(request);
    }
    [HttpPost("CreatePage")]
    public async Task<ActionResult<CreatePageResponse>> Create([FromBody] CreatePageRequest request)
    {
        return await Mediator.Send(request);
    }
}
