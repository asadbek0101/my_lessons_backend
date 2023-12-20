using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.PageFeature.UpdatePage;

public sealed record UpdatePageRequest : IRequest<ApiResponse>
{
    public int LessonId { get; set; }
    public string PageType { get; set; }
    public string PageDetails { get; set; }
}
