using AutoMapper;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.RoleRepository.GetAllRole;

public class GetAllRoleMapper : Profile
{
    public GetAllRoleMapper()
    {
        CreateMap<ApplicationRole, GetAllRoleResponse>();
    }
}
