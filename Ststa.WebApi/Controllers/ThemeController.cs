using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.ThemeFeature.CreateTheme;
using Ststa.Application.Features.ThemeFeature.GetAllTheme;
using Ststa.Application.Features.ThemeFeature.GetThemeByLessonId;
using Ststa.Application.Features.ThemeFeature.UpdateTheme;
using Ststa.WebApi.Exceptions;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThemeController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<GetAllThemeResponse>>> GetAll([FromQuery] GetAllThemeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetByLesson")]
    public async Task<ActionResult<List<GetThemeByLessonIdResponse>>> GetByLesson([FromQuery] GetThemeByLessonIdRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<CreateThemeResponse>> Create([FromBody] CreateThemeRequest request){
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateThemeRequest request)
    {
        return await Mediator.Send(request);
    }
}
