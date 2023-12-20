namespace Ststa.Application.Features.PageFeature.GetAllPage;

public sealed record GetAllPageResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string PageType { get; set; }
    public string PageDetails { get; set; }
}
