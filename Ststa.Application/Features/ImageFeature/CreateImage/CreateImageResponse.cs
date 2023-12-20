
namespace Ststa.Application.Features.ImageFeature.CreateImage;

public sealed record CreateImageResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
}
