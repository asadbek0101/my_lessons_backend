using Ststa.Domain.Entites.CustomUsers;
using Ststa.Infrastructure.AuthRepository.LoginUser;

namespace Ststa.Infrastructure.Interfaces;

public interface ILoginHandler
{
    public Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken);
}
