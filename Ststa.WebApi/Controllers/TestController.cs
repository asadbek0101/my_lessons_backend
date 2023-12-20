using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ststa.Application.Features.TestFeature.CreateTest;
using Ststa.Application.Features.TestFeature.GetAllTest;
using Ststa.Application.Features.TestFeature.GetTestsByLessonId;
using Ststa.Application.Features.TestFeature.UpdateTest;

namespace Ststa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<List<GetAllTestResponse>> GetAll([FromQuery] GetAllTestRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetTests")]
    public async Task<GetTestsResponse> GetTests([FromQuery] GetTestsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<CreateTestResponse> Create([FromBody ]CreateTestRequest request) 
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<UpdateTestResponse> Update([FromBody] UpdateTestRequest request)
    {
        return await Mediator.Send(request);
    }
}
