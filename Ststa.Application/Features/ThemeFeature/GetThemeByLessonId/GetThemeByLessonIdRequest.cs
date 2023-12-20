using MediatR;

namespace Ststa.Application.Features.ThemeFeature.GetThemeByLessonId;

public sealed record GetThemeByLessonIdRequest : IRequest<List<GetThemeByLessonIdResponse>>
{
    public int LessonId { get; set; }
}
