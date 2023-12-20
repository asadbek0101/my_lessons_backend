
namespace Ststa.Domain.Entites;

public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerTitle { get; set; }
    public string IsRight { get; set; }
    public Question Question { get; set; }
}
