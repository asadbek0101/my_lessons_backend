using MediatR;

namespace Ststa.Infrastructure.AuthRepository.LoginUser;

public sealed record LoginUserRequest : IRequest<LoginUserResponse>
{
    //public string UserName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
