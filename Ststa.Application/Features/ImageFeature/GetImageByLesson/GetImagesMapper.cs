using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ImageFeature.GetImageByLesson;

public class GetImagesMapper : Profile
{
    public GetImagesMapper()
    {
        CreateMap<Images, GetImagesResponse>();
    }
}
