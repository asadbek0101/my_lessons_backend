
using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.TestFeature.GetAllTest;

public class GetAllTestMapper : Profile
{
    public GetAllTestMapper()
    {
        CreateMap<Test, GetAllTestResponse>();
    }
}
