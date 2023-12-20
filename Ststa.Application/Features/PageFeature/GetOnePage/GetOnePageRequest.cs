using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.PageFeature.GetOnePage;

public sealed record GetOnePageRequest : IRequest<ApiResponse>
{
    public int ThemeId { get; set; }
    public string ThemeType { get; set; }
}
