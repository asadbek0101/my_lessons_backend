namespace Ststa.Infrastructure.AuthRepository.ResetPassword;

public sealed record ResetPasswordResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
}
