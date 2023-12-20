using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.TestFeature.CreateTest;

public class CreateTestMapper : Profile
{
    public CreateTestMapper()
    {
        CreateMap<CreateTestQuestion, Question>();
        CreateMap<CreateTestAnswer, Answer>();
    }
}
