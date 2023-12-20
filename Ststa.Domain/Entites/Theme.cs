using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Domain.Entites;

public class Theme : BaseEntity
{
    public int LessonId { get; set; }
    public string ThemeType { get; set; } = string.Empty;
    public string ThemeTitle { get; set; } = string.Empty; 
    public Lesson Lesson { get; set; }
    public List<Test> Tests { get; set; }
    public List<Page> Pages { get; set; }
    public List<Images> Images { get; set; }
}
