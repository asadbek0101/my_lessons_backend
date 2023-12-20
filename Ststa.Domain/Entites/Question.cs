
namespace Ststa.Domain.Entites;

public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string QuestionTitle { get; set; }
    public Test Test { get; set; }
    public List<Answer> Answers { get; set; }
}
