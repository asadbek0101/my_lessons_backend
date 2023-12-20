using AutoMapper;
using MediatR;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.CreateLesson;

public class CreateLessonHandler : IRequestHandler<CreateLessonRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLessonHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateLessonRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var lesson = _mapper.Map<Lesson>(request);
            var data = new CreateLessonResponse();

            if(lesson == null)
            {
                type = ResponseType.Failure;
            }else
            {
                _dbContext.Lessons.Add(lesson);
                await _unitOfWork.Save(cancellationToken);
                data = _mapper.Map<CreateLessonResponse>(lesson);
            }

            return ResponseHandler.GetAppResponse(type, data);
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
       
    }
}
