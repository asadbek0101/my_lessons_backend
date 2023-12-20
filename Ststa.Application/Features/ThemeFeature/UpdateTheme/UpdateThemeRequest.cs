using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ThemeFeature.UpdateTheme;

public sealed record UpdateThemeRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string ThemeTitle { get; set; }
    public string Status { get; set; }
}
