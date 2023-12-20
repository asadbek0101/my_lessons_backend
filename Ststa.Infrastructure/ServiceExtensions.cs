using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Ststa.Infrastructure.Interfaces;
using Ststa.Infrastructure.AuthRepository.RegisterUser;
using Microsoft.AspNetCore.Identity;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.Infrastructure.AuthRepository.LoginUser;

namespace Ststa.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IRegisterUserHandler, RegisterUserHandler>();
        services.AddTransient<ILoginHandler, LoginUserHandler>();
        services.AddScoped<UserManager<ApplicationUser>>();
    }
}
