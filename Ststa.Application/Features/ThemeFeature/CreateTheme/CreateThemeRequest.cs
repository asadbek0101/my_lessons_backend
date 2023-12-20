using MediatR;

namespace Ststa.Application.Features.ThemeFeature.CreateTheme;

public sealed record CreateThemeRequest : IRequest<CreateThemeResponse>
{
    public int LessonId { get; set; }
    public string Type { get; set; }
}
