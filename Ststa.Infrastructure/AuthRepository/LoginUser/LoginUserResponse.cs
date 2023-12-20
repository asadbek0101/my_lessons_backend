
namespace Ststa.Infrastructure.AuthRepository.LoginUser;

public sealed record LoginUserResponse
{
    public bool Status { get; set; }
    public string? Token { get; set; }
    public required string Message { get; set; }

}
