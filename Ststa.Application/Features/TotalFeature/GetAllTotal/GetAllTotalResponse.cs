
namespace Ststa.Application.Features.TotalFeature.GetAllTotal;

public sealed record GetAllTotalResponse
{
    public int TotalAll { get; set; }
    public int TotalLessonCount { get; set; }
    public int TotalTestCount { get; set; }
    public int TotalVideoCount { get; set; }
    public int TotalPPTCount { get; set; }
    public int TotalLaboratoryCount { get; set; }
    public int TotalPracticalCount { get; set; }

    public int TotalUserCount { get; set; }
}
