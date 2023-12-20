
namespace Ststa.Application.Features.LessonFeature.GetOneLesson;

public sealed record GetOneLessonResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string LessonNumber { get; set; }
}
