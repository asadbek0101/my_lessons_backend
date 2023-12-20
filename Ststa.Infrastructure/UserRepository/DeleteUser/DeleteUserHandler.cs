using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.WebApi.Exceptions;

namespace Ststa.Infrastructure.UserRepository.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public DeleteUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var ids = request.Ids;

        try
        {
            var type = ResponseType.Success;
            if (ids.Any())
            {
                
                foreach (var id in ids)
                {
                    var user = await _userManager.FindByIdAsync(id.ToString());

                    if (user != null)
                    {
                        await _userManager.DeleteAsync(user);
                    }
                }
            }
            else
            {
                type = ResponseType.NotFound;
            }

            return ResponseHandler.GetAppResponse(type, "Users Deleted");
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
