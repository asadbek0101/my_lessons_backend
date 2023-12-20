using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.PageFeature.GetOnePage;

public class GetOnePageMapper : Profile
{
    public GetOnePageMapper()
    {
        CreateMap<Page, GetOnePageResponse>();
    }
}
