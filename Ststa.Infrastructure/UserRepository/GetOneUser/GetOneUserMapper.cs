using AutoMapper;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.UserRepository.GetOneUser;

public class GetOneUserMapper : Profile
{
    public GetOneUserMapper()
    {
        CreateMap<GetOneUserRequest, ApplicationUser>();
    }
}
