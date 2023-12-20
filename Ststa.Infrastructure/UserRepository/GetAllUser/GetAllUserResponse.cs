namespace Ststa.Infrastructure.UserRepository.GetAllUser;

public sealed record GetAllUserResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public string CreatedDate { get; set; }
    public string Status { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}
