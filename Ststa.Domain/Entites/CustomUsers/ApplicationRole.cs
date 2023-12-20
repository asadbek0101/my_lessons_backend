using Microsoft.AspNetCore.Identity;

namespace Ststa.Domain.Entites.CustomUsers;

public class ApplicationRole : IdentityRole<int>
{
    public override string? Name { get => base.Name; set => base.Name = value; }
}
