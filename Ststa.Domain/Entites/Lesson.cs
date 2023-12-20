
namespace Ststa.Domain.Entites;

public class Lesson : BaseEntity
{
    public string LessonTitle { get; set; }
    public string LessonNumber { get; set; }
    public List<Theme> Themes { get; set;}
}
