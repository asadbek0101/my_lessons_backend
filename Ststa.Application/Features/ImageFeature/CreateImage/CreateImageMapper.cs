
using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ImageFeature.CreateImage;

public class CreateImageMapper : Profile
{
    public CreateImageMapper()
    {
        CreateMap<CreateImageRequest, Images>();
        CreateMap<Images, CreateImageResponse>();
    }
}
