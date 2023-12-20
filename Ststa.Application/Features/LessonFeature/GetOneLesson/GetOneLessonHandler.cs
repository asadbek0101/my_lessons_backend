using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.GetOneLesson;

public class GetOneLessonHandler : IRequestHandler<GetOneLessonRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;

    public GetOneLessonHandler(IMapper mapper, IStstaDBContext ststaDBContext)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
    }
    public async Task<ApiResponse> Handle(GetOneLessonRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var lesson = await _dbContext.Lessons.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var data = new GetOneLessonResponse();
            if (lesson == null)
            {
                type = ResponseType.NotFound;
            }
            else
            {
                data = _mapper.Map<GetOneLessonResponse>(lesson);
            }

            return ResponseHandler.GetAppResponse(type, data);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
