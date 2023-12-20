using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.Persistance.Repositores;
using System.Data;

namespace Ststa.Persistance;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnection");
        services.AddDbContext<StstaDbContext>(opt => opt.UseNpgsql(connectionString));
        services.AddIdentityCore<ApplicationUser>(options => {
            options.SignIn.RequireConfirmedAccount = true;
            options.User.RequireUniqueEmail = false;
            
        }).AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<StstaDbContext>();

        services.AddAuthorizationCore(options =>
        {
            //For Branch Controller
            options.AddPolicy("isCreateUser", policy => policy.RequireClaim("isCreateUser"));
            options.AddPolicy("GetBranchListWithPagination", policy => policy.RequireClaim("GetBranchListWithPagination"));
            options.AddPolicy("GetBranchDetails", policy => policy.RequireClaim("GetBranchDetails"));
            options.AddPolicy("CreateBranch", policy => policy.RequireClaim("CreateBranch"));
            options.AddPolicy("UpdateBranch", policy => policy.RequireClaim("UpdateBranch"));
            options.AddPolicy("DeleteBranch", policy => policy.RequireClaim("DeleteBranch"));
            options.AddPolicy("DeleteBranches", policy => policy.RequireClaim("DeleteBranches"));

        });


        services.AddScoped<IStstaDBContext, StstaDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
