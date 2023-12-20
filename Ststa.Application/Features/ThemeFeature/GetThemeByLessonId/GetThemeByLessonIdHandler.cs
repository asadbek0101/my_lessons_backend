using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;

namespace Ststa.Application.Features.ThemeFeature.GetThemeByLessonId;

public class GetThemeByLessonIdHandler : IRequestHandler<GetThemeByLessonIdRequest, List<GetThemeByLessonIdResponse>>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;

    public GetThemeByLessonIdHandler(IMapper mapper, IStstaDBContext ststaDBContext)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
    }
    public async Task<List<GetThemeByLessonIdResponse>> Handle(GetThemeByLessonIdRequest request, CancellationToken cancellationToken)
    {
        var themes = await _dbContext.Themes.Where(x => x.LessonId == request.LessonId).ToListAsync();
        return _mapper.Map<List<GetThemeByLessonIdResponse>>(themes);
    }
}
