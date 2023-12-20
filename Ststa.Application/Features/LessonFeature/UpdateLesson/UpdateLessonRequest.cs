using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.UpdateLesson;

public sealed record UpdateLessonRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string LessonTitle { get; set; }
    public string LessonNumber { get; set; }
    public string Status { get; set; }
}
