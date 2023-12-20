namespace Ststa.Domain.Entites;

public class Test
{
    public int Id { get; set; }
    public int ThemeId { get; set; }
    public string? TestTitle { get; set; }
    public Theme Theme { get; set; }
    public List<Question> Questions { get; set; }
}
