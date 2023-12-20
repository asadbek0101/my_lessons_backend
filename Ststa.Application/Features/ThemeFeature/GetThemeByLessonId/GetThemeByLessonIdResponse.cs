namespace Ststa.Application.Features.ThemeFeature.GetThemeByLessonId;

public sealed record GetThemeByLessonIdResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string ThemeType { get; set; }
}
