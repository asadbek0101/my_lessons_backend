
namespace Ststa.Domain.Entites;

public class Result
{
    public int Id { get; set; }
    public int AllQuestionCount { get; set; }
    public int RightAnswerCount { get; set; }
    public int UserId { get; set; }
    public int TestId { get; set; }
    public string Date { get; set; }
}
