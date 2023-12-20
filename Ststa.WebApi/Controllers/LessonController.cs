using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.LessonFeature.CreateLesson;
using Ststa.Application.Features.LessonFeature.DeleteLesson;
using Ststa.Application.Features.LessonFeature.GetAllLesson;
using Ststa.Application.Features.LessonFeature.GetOneLesson;
using Ststa.Application.Features.LessonFeature.UpdateLesson;
using Ststa.WebApi.Exceptions;
using System.Security.Principal;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : BaseController
{
    [HttpGet("GetAll")]
    [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatorApiResponse>> Get([FromQuery] GetAllLessonRequest request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> Get([FromQuery] GetOneLessonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateLessonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateLessonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<DeleteLessonResponse>> Delete([FromBody] DeleteLessonRequest request)
    {
        return await Mediator.Send(request);
    }

}
