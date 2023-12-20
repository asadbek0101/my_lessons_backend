
namespace Ststa.Domain.Entites;

public class Images
{
    public int Id { get; set; }
    public int ThemeId { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
    public Theme Theme { get; set; }
}
