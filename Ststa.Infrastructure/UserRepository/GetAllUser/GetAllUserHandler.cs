using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.WebApi.Exceptions;

namespace Ststa.Infrastructure.UserRepository.GetAllUser;

public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, PaginatorApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;
    public GetAllUserHandler(UserManager<ApplicationUser> userManager, IPaginator paginator, IMapper mapper)
    {
        _userManager = userManager;
        _paginator = paginator;
        _mapper = mapper;
    }
    public async Task<PaginatorApiResponse> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var searchValue = request.SearchValue;
        var status = request.Status;
        var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
        var users = new List<ApplicationUser>();
        List<GetAllUserResponse> usersResponse = new List<GetAllUserResponse>();
        try
        {
            ResponseType type = ResponseType.Success;
            if (searchValue != null && status == null)
            {
                users = await _userManager
                    .Users
                    .OrderBy(u => u.Id)
                    .Where(u => u.Email.ToUpper().Contains(searchValue) || u.FirstName.ToUpper().Contains(searchValue) || u.LastName.ToUpper().Contains(searchValue) || u.UserName.ToUpper().Contains(searchValue))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }else if(searchValue == null && status != null)
            {
                users = await _userManager
                    .Users
                    .OrderBy(u => u.Id)
                    .Skip(skipRows)
                    .Where(u => u.Status == status)
                    .Take(request.PageSize)
                    .ToListAsync();
            }else if(searchValue != null && status != null)
            {
                users = await _userManager
                   .Users
                   .OrderBy(u => u.Id)
                   .Where(u => u.Email.ToUpper().Contains(searchValue) || u.FirstName.ToUpper().Contains(searchValue) || u.LastName.ToUpper().Contains(searchValue) || u.UserName.ToUpper().Contains(searchValue))
                   .Where(u => u.Status == status)
                   .Skip(skipRows)
                   .Take(request.PageSize)
                   .ToListAsync();
            }else if(searchValue == null && status == null)
            {
                users = await _userManager
                  .Users
                  .OrderBy(u => u.Id)
                  .Skip(skipRows)
                  .Take(request.PageSize)
                  .ToListAsync();
            }
            ;
            foreach (var user in users)
            {
                var rolename = await _userManager.GetRolesAsync(user);

                usersResponse.Add(new GetAllUserResponse
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    CreatedBy = user.CreatedBy,
                    CreatedDate = user.CreatedDate,
                    Status = user.Status,
                    FullName = user.FirstName + " " + user.LastName,
                    Role = rolename[0]?.ToString(),
                    Id = user.Id
                });
            }

            var totalRowCount = await _userManager.Users.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            return ResponseHandler.GetAppResponseWithPages(type, totalPageCount, totalRowCount, usersResponse);
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponseWithPages(ex);
        }
    }
}
