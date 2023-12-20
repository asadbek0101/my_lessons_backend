namespace Ststa.Application.Features.TestFeature.UpdateTest;

public class UpdateTestQuestion
{
    public int? Id { get; set; }
    public int TestId { get; set; }
    public string Title { get; set; }
    public List<UpdateTestAnswer> Answers { get; set; }
}
