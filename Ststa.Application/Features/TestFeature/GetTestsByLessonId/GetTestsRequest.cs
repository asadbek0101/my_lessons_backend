
using MediatR;

namespace Ststa.Application.Features.TestFeature.GetTestsByLessonId;

public sealed record GetTestsRequest : IRequest<GetTestsResponse>
{
    public int ThemeId { get; set; }
}
