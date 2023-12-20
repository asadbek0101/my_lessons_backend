using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.PageFeature.GetAllPage;

public class GetAllPageMapper : Profile
{
    public GetAllPageMapper()
    {
        CreateMap<Page, GetAllPageResponse>();
    }
}
