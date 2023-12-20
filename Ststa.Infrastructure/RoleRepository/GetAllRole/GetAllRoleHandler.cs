
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.RoleRepository.GetAllRole;

public class GetAllRoleHandler : IRequestHandler<GetAllRoleReqest, List<GetAllRoleResponse>>
{
    private readonly RoleManager<ApplicationRole> _roleManger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetAllRoleHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
    {
        _userManager = userManager;
        _roleManger = roleManager;      
        _mapper = mapper;
    }
    public async Task<List<GetAllRoleResponse>> Handle(GetAllRoleReqest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        var userRoles = await _userManager.GetRolesAsync(user);

        var role = userRoles[0].ToString();
        var roles = await _roleManger.Roles.ToListAsync();
        var response = new List<GetAllRoleResponse>();

        if (role == null)
        {
            response = null;
        }else if (role == "Asadbek") 
        {
            roles.ForEach((r) =>
            {
                if (r.Name != "Asadbek") {
                    response.Add(new GetAllRoleResponse
                    {
                        Id = r.Id,
                        Name = r.Name
                    });
                }
                
            });
        }else if(role == "Admin")
        {
            roles.ForEach((r) =>
            {
                if (r.Name != "Asadbek" && r.Name != "Admin") {
                    response.Add(new GetAllRoleResponse
                    {
                        Id = r.Id,
                        Name = r.Name
                    });
                }
                
            });
        }
        else if(role == "Teacher")
        {
            roles.ForEach((r) =>
            {
                if (r.Name != "Asadbek" && r.Name != "Admin" && r.Name != "Teacher")
                {
                    response.Add(new GetAllRoleResponse
                    {
                        Id = r.Id,
                        Name = r.Name
                    });
                }
               
            });
        }
        else if (role == "Assistant")
        {
            roles.ForEach((r) =>
            {
                if (r.Name != "Asadbek" && r.Name != "Admin" && r.Name != "Teacher" && r.Name != "Assistant")
                {
                    response.Add(new GetAllRoleResponse
                    {
                        Id = r.Id,
                        Name = r.Name
                    });
                }
                
            });
        }

        return _mapper.Map<List<GetAllRoleResponse>>(response);
    }
}
