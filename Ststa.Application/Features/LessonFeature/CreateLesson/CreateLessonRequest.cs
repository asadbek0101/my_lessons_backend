
using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.CreateLesson;

public sealed record CreateLessonRequest : IRequest<ApiResponse>
{
    public int CreatedBy { get; set; }
    public string CreatedDate { get; set; }
    public string LessonTitle { get; set; }
    public string LessonNumber { get; set; }
}
