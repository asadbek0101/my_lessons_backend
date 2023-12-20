
using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.PageFeature.CreatePage;

public class CreatePageMapper : Profile
{
    public CreatePageMapper()
    {
        CreateMap<CreatePageRequest, Page>();
        CreateMap<Page, CreatePageResponse>();
    }
}
