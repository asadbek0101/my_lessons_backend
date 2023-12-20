

namespace Ststa.Application.Features.TestFeature.GetTestsByLessonId;

public class GetTestsQuestion
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string Title { get; set; }
    public List<GetTestsAnswer> Answers { get; set; }
}
