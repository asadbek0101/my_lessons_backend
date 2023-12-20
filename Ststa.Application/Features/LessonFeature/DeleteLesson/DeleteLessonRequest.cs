using MediatR;

namespace Ststa.Application.Features.LessonFeature.DeleteLesson;

public sealed record DeleteLessonRequest : IRequest<DeleteLessonResponse>
{
    public List<int> Ids { get; set; }
}
