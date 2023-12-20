using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.Infrastructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;

namespace Ststa.Infrastructure.AuthRepository.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>, ILoginHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _config;

    public LoginUserHandler(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }
    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var hasUser = await _userManager.FindByNameAsync(request.Username);
       
        if (hasUser != null)
        {
            var isCorrect = await _userManager.CheckPasswordAsync(hasUser, request.Password);

            if (!isCorrect)
            {
                return new LoginUserResponse { Message = "Password is invalid", Status = false };
            }
            else
            {
                var token = await GenerateToken(hasUser);
                return new LoginUserResponse { Message = "Success", Status = true, Token = token };
            }
        }
        else
        {
            return new LoginUserResponse { Message = "User not found!", Status = false };
        }
    }

    private async Task<string> GenerateToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>()
        {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        //var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var userRole in userRoles)
        {
            var role = await _roleManager.FindByNameAsync(userRole);
            if (role != null)
            {
                claims.Add(new Claim("role", userRole));
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }
            }
        }

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
             _config["Jwt:Audience"],
             claims,
             expires: DateTime.Now.AddMilliseconds(5),
             signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
