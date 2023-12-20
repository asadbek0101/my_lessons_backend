namespace Ststa.Domain.Entites;

public class Page
{
    public int Id { get; set; }
    public int ThemeId { get; set; }
    public string PageType { get; set; }
    public string PageDetails { get; set; }
    public Theme Theme { get; set; }
}
