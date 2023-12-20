using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.UserRepository.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public CreateUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        var isCreateAsync = await _userManager.CreateAsync(user, request.Password);

        var isAsyncToRole = await _userManager.AddToRoleAsync(user, request.RoleName);

        if (isCreateAsync.Succeeded && isAsyncToRole.Succeeded)
        {
            return new CreateUserResponse { Message = "User Created", Status = "Success" };
        }
        else
        {
            var errorMessage = "";
            foreach (var item in isCreateAsync.Errors)
            {
                errorMessage = errorMessage + item.Description + " ";
            }
            return new CreateUserResponse { Message = errorMessage, Status = "Failed" };
        }
    }
}
