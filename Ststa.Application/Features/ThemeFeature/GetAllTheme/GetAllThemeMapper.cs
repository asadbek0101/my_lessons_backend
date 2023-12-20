
using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ThemeFeature.GetAllTheme;

public class GetAllThemeMapper : Profile
{
    public GetAllThemeMapper()
    {
        CreateMap<GetAllThemeRequest, Theme>();
        CreateMap<Theme, GetAllThemeResponse>();
    }
}
