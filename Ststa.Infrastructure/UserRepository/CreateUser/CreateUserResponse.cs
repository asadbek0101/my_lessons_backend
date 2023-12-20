namespace Ststa.Infrastructure.UserRepository.CreateUser;

public sealed record CreateUserResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
}
