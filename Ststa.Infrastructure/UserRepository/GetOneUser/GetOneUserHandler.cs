using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.UserRepository.GetOneUser;

public class GetOneUserHandler : IRequestHandler<GetOneUserRequest, GetOneUserResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    public GetOneUserHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<GetOneUserResponse> Handle(GetOneUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);
        var responseUser = await _userManager.FindByIdAsync(user.Id.ToString());
        var roleName = await _userManager.GetRolesAsync(user);
        GetOneUserResponse response = new GetOneUserResponse()
        {
            Id = responseUser.Id,
            Email = responseUser.Email,
            UserName = responseUser.UserName,
            Role = roleName[0]?.ToString(),
        };
        return response;
    }
}
