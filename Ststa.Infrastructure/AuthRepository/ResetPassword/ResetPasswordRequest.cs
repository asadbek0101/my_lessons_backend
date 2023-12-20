using MediatR;

namespace Ststa.Infrastructure.AuthRepository.ResetPassword;

public sealed record ResetPasswordRequest : IRequest<ResetPasswordResponse>
{
    public string Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
