
namespace Ststa.Application.Features.LessonFeature.GetAllLesson;

public record class GetAllLessonResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string Status { get; set; }
    public string CreatedDate { get; set; }
    public string LessonTitle { get; set; }
    public string LessonNumber { get; set; }
}
