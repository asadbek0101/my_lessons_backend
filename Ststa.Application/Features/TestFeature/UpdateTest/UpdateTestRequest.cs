using MediatR;

namespace Ststa.Application.Features.TestFeature.UpdateTest;
public sealed record UpdateTestRequest : IRequest<UpdateTestResponse>
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string TestTitle { get; set; }
    public List<UpdateTestQuestion> Questions { get; set; }
}
