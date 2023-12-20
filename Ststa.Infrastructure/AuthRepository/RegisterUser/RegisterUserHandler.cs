using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.Infrastructure.Interfaces;

namespace Ststa.Infrastructure.AuthRepository.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>, IRegisterUserHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    public RegisterUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
        };
        var isCreateAsync = await _userManager.CreateAsync(user, request.Password);

        var isAsyncToRole = await _userManager.AddToRoleAsync(user, "Guest");

        if (isCreateAsync.Succeeded && isAsyncToRole.Succeeded)
        {
           
                return new RegisterUserResponse { Message = "User registered", Status = "Success" };
        }
        else
        {
            var errorMessage = "";
            foreach (var item in isCreateAsync.Errors)
            {
                errorMessage = errorMessage + item.Description + " "; 
            }
            return new RegisterUserResponse { Message = errorMessage, Status = "Failed" };
        }
    }
}
