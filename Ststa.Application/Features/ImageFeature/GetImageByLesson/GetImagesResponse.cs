
namespace Ststa.Application.Features.ImageFeature.GetImageByLesson;

public sealed record GetImagesResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
}
