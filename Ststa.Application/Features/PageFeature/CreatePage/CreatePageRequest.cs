using MediatR;

namespace Ststa.Application.Features.PageFeature.CreatePage;

public sealed record CreatePageRequest : IRequest<CreatePageResponse>
{
    public int ThemeId { get; set; }
    public string PageType { get; set; }
    public string PageDetails { get; set; }
}
