using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;

namespace Ststa.Application.Features.ThemeFeature.GetAllTheme;

public class GetAllThemeHandler : IRequestHandler<GetAllThemeRequest, List<GetAllThemeResponse>>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IPaginator _paginator;

    public GetAllThemeHandler(IMapper mapper, IStstaDBContext ststaDBContext, IPaginator paginator)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _paginator = paginator;
    }
    public async Task<List<GetAllThemeResponse>> Handle(GetAllThemeRequest request, CancellationToken cancellationToken)
    {
        var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
        var lessons = await _dbContext.Themes.Where(t => t.ThemeType == request.ThemeType).Skip(skipRows).Take(request.PageSize).OrderBy(t => t.Id).ToListAsync();
        return _mapper.Map<List<GetAllThemeResponse>>(lessons);
    }
}
