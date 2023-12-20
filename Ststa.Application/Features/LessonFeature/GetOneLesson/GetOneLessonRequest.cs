using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.GetOneLesson;

public sealed record GetOneLessonRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}