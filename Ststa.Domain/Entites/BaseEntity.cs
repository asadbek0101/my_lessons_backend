namespace Ststa.Domain.Entites;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public int CreatedBy { get; set; } = 0;
    public int UpdatedBy { get; set; } = 0;
    public string CreatedDate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
