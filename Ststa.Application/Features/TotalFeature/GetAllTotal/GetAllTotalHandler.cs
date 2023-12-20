
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.TotalFeature.GetAllTotal;

public class GetAllTotalHandler : IRequestHandler<GetAllTotalRequst, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManger;
    public GetAllTotalHandler(IMapper mapper, IStstaDBContext ststaDBContext, IPaginator paginator, UserManager<ApplicationUser> userManger)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _paginator = paginator;
        _userManger = userManger;
    }
    public async Task<ApiResponse> Handle(GetAllTotalRequst request, CancellationToken cancellationToken)
    {
        try
        {
            var data = new GetAllTotalResponse();
            ResponseType type = ResponseType.Success;

            var lessonsCount = await _dbContext.Lessons.CountAsync();
            var usersCount = await _userManger.Users.CountAsync();
            var practicalWorksCount = await _dbContext.Themes.Where(p => p.ThemeType == "AA").CountAsync();
            var laboratoryWorksCount = await _dbContext.Themes.Where(p => p.ThemeType == "AB").CountAsync();
            var pptsCount = await _dbContext.Themes.Where(p => p.ThemeType == "AC").CountAsync();
            var videosCount = await _dbContext.Themes.Where(p => p.ThemeType == "AD").CountAsync();
            var testsCount = await _dbContext.Themes.Where(p => p.ThemeType == "AE").CountAsync();

                data.TotalAll = lessonsCount + testsCount + practicalWorksCount + laboratoryWorksCount + pptsCount;
                data.TotalLessonCount = lessonsCount;
                data.TotalPracticalCount = practicalWorksCount;
                data.TotalLaboratoryCount = laboratoryWorksCount;
                data.TotalPPTCount = pptsCount;
                data.TotalTestCount = testsCount;
                data.TotalVideoCount = videosCount;
                data.TotalUserCount = usersCount;

            return ResponseHandler.GetAppResponse(type, data);
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
