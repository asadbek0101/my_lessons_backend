
using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.CreateImage;

public sealed record CreateImageRequest : IRequest<ApiResponse>
{
    public int LessonId { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
}
