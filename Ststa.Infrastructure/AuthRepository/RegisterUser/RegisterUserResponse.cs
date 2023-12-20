namespace Ststa.Infrastructure.AuthRepository.RegisterUser;

public sealed record RegisterUserResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
}
