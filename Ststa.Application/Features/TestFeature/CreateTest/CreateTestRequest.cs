using MediatR;

namespace Ststa.Application.Features.TestFeature.CreateTest;

public sealed record CreateTestRequest : IRequest<CreateTestResponse>
{
    public int LessonId { get; set; }
    public List<CreateTestQuestion> Questions { get; set; }
}
