using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Infrastructure.UserRepository.DeleteUser;

public sealed record DeleteUserRequest : IRequest<ApiResponse>
{
    public List<int> Ids { get; set; }
}
