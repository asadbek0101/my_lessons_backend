
namespace Ststa.Application.Features.ThemeFeature.GetAllTheme;

public sealed record GetAllThemeResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int LessonId { get; set; }
    public string CreatedDate { get; set; }
    public string Status { get; set; }
    public string ThemeTitle { get; set; }
    public string ThemeType { get; set; }
}
