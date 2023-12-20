using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.ImageFeature.CreateImage;
using Ststa.Application.Features.ImageFeature.GetAllImage;
using Ststa.Application.Features.ImageFeature.GetImageByLesson;
using Ststa.WebApi.Exceptions;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ApiResponse> GetAll([FromQuery] GetAllImageRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetSome")]
    public async Task<ApiResponse> GetByLesson([FromQuery] GetImagesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ApiResponse> Create([FromBody] CreateImageRequest request)
    {
        return await Mediator.Send(request);
    }
}
