using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;

namespace Ststa.Application.Features.LessonFeature.DeleteLesson;

public class DeleteLessonHandler : IRequestHandler<DeleteLessonRequest, DeleteLessonResponse>
{
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLessonHandler(IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteLessonResponse> Handle(DeleteLessonRequest request, CancellationToken cancellationToken)
    {
        var ids = request.Ids;
        foreach (var id in ids)
        {
            var lesson = await _dbContext.Lessons.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (lesson != null)
            {
                lesson.Status = "2";
                _dbContext.Lessons.Update(lesson);
                await _unitOfWork.Save(cancellationToken);
            }
        }

        var resposne = new DeleteLessonResponse();
        resposne.Response = "Deleted!";
        return resposne;
    }
}
