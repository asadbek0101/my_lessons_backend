using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyLC.Application.Common.Behaviors;
using Ststa.Application.Helpers;
using Ststa.Application.Interfaces;
using System.Reflection;

namespace Ststa.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IPaginator, Pagintator>();
    }
}
