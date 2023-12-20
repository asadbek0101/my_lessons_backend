using MediatR;

namespace Ststa.Infrastructure.AuthRepository.RegisterUser;

public sealed record RegisterUserRequest : IRequest<RegisterUserResponse>
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
