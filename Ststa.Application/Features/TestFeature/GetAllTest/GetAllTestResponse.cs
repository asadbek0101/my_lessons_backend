
namespace Ststa.Application.Features.TestFeature.GetAllTest;

public sealed record GetAllTestResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string? TestTitle { get; set; }
}
