using Microsoft.AspNetCore.Identity;

namespace Ststa.Domain.Entites.CustomUsers;

public class ApplicationUser : IdentityUser<int>
{
    public int CreatedBy { get; set; }
    public string CreatedDate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public override string? Email { get => base.Email; set => base.Email = value; }
    public override string? UserName { get => base.UserName; set => base.UserName = value; }
    public override string? PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
    public List<Lesson> Lessons { get; set; }
}
