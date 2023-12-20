using MediatR;

namespace Ststa.Application.Features.ThemeFeature.GetAllTheme;

public sealed record GetAllThemeRequest : IRequest<List<GetAllThemeResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string ThemeType { get; set; }
}
