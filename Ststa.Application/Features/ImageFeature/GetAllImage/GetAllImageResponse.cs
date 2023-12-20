
namespace Ststa.Application.Features.ImageFeature.GetAllImage;

public sealed record GetAllImageResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
}
