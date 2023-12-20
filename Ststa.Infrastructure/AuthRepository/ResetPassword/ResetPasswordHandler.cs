using MediatR;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;

namespace Ststa.Infrastructure.AuthRepository.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public ResetPasswordHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {

        //var ss = _userManager.ad

        throw new NotImplementedException();
    }
}
