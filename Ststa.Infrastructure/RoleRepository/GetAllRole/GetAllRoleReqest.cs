using MediatR;

namespace Ststa.Infrastructure.RoleRepository.GetAllRole;

public sealed record GetAllRoleReqest : IRequest<List<GetAllRoleResponse>>
{
    public int UserId { get; set; }
}
