
namespace Ststa.Application.Features.PageFeature.GetOnePage;

public sealed record GetOnePageResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string PageType { get; set; }
    public string PageDetails { get; set; }
}
