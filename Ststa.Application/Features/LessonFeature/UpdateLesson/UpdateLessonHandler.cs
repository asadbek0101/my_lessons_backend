using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.UpdateLesson;

public class UpdateLessonHandler : IRequestHandler<UpdateLessonRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLessonHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateLessonRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var lesson = await _dbContext.Lessons.Where(l => l.Id == request.Id).FirstOrDefaultAsync();
            var data = new UpdateLessonResponse();
            if (lesson == null)
            {
                type = ResponseType.Failure;
            }
            else
            {
                lesson.LessonTitle = request.LessonTitle;
                lesson.LessonNumber = request.LessonNumber;
                lesson.Status = request.Status;
                _dbContext.Lessons.Update(lesson);
                await _unitOfWork.Save(cancellationToken);
                data = _mapper.Map<UpdateLessonResponse>(lesson);
            }
            return ResponseHandler.GetAppResponse(type, data);
           
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
       
    }
}
