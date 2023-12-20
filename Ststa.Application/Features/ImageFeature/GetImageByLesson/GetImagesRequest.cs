using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.GetImageByLesson;

public sealed record GetImagesRequest : IRequest<ApiResponse>
{
    public int LessonId { get; set; }
    public string Type { get; set; }
}
