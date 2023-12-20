using MediatR;

namespace Ststa.Infrastructure.UserRepository.GetOneUser;

public sealed record GetOneUserRequest : IRequest<GetOneUserResponse>
{
    public string Id { get ; set; }
}
