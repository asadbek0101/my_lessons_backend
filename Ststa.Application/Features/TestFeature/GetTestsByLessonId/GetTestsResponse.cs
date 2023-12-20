using Ststa.Domain.Entites;

namespace Ststa.Application.Features.TestFeature.GetTestsByLessonId;

public sealed record GetTestsResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string TestTitle { get; set; }
    public List<GetTestsQuestion> Questions { get; set; }
}
