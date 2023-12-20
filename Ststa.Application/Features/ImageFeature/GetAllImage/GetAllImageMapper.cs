using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ImageFeature.GetAllImage;

public class GetAllImageMapper : Profile
{
    public GetAllImageMapper()
    {
        CreateMap<Images, GetAllImageResponse>();
    }
}
