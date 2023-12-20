
using Ststa.Infrastructure.AuthRepository.RegisterUser;

namespace Ststa.Infrastructure.Interfaces;

public interface IRegisterUserHandler
{
    public Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken);
}
