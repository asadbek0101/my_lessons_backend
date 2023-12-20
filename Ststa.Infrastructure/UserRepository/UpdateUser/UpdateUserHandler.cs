
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.UserRepository.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    public UpdateUserHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateUserResponse();
        var user = await _userManager.FindByIdAsync(request.Id.ToString());

        if (user == null)
        {
            response.Message = "User Not Found";
            return response;
        }
        else
        {
            user.Email = request.Email;
            user.UserName = request.UserName;
        }
        
        var updated = _userManager.UpdateAsync(user);

        if (updated != null)
        {
            var roleName = await _userManager.GetRolesAsync(user);
            if (roleName != null)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName[0].ToString());
                await _userManager.AddToRoleAsync(user, request.RoleName);
            }
            response.Message = "Updated";
        }
        return response;
    }
}
