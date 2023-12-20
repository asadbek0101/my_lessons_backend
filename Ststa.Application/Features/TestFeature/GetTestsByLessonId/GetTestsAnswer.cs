
namespace Ststa.Application.Features.TestFeature.GetTestsByLessonId;

public class GetTestsAnswer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Title { get; set; }
    public string IsRight { get; set; }
}
