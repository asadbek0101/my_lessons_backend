using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;
using Ststa.Domain.Entites.CustomUsers;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.GetAllLesson;

public sealed class GetAllLessonHandler : IRequestHandler<GetAllLessonRequest, PaginatorApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllLessonHandler(IMapper mapper, IStstaDBContext ststaDBContext, IPaginator paginator, UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _paginator = paginator;
        _userManager = userManager;
    }

    public async Task<PaginatorApiResponse> Handle(GetAllLessonRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var lessons = new List<Lesson>();
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
            var searchValue = request.SearchValue;
            var status = request.Status;
            if(searchValue == null && status == null)
            {
                lessons = await _dbContext
                    .Lessons
                    .OrderBy(x => x.Id)
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            } else if(searchValue == null && status != null) 
            {
                lessons = await _dbContext
                    .Lessons
                    .OrderBy(x => x.Id)
                    .Where(l => l.Status == status)
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            } else if (searchValue != null && status == null)
            {
                lessons = await _dbContext
                    .Lessons
                    .OrderBy(x => x.Id)
                    .Where(l => l.LessonTitle.ToUpper().Contains(searchValue) || l.LessonNumber.ToUpper().Contains(searchValue))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }
            else if (searchValue != null && status != null)
            {
                lessons = await _dbContext
                    .Lessons
                    .OrderBy(x => x.Id)
                    .Where(l => l.Status == status)
                    .Where(l => (l.LessonTitle.ToUpper().Contains(searchValue) || l.LessonNumber.ToUpper().Contains(searchValue)))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }

            var data = new List<GetAllLessonResponse>();
            var totalRowCount = 0;
            var totalPageCount = 0;

            if (!lessons.Any())
            {
                type = ResponseType.NotFound;
            }
            else
            {
                data = _mapper.Map<List<GetAllLessonResponse>>(lessons);
                totalRowCount = await _dbContext.Lessons.CountAsync();
                totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            }

            return ResponseHandler.GetAppResponseWithPages(type, totalPageCount, totalRowCount, data);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponseWithPages(ex);
        }
    }
}
