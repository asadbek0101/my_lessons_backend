using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ThemeFeature.CreateTheme;

public class CreateThemeMapper : Profile
{
    public CreateThemeMapper()
    {
        CreateMap<CreateThemeRequest, Theme>();
        CreateMap<Theme, CreateThemeResponse>();
    }
}
