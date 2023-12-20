using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ThemeFeature.GetThemeByLessonId;
public class GetThemeByLessonIdMapper : Profile
{
    public GetThemeByLessonIdMapper()
    {
        CreateMap<Theme, GetThemeByLessonIdResponse>();
    }
}
