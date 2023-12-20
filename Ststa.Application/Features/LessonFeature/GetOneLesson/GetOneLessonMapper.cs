using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.LessonFeature.GetOneLesson;

public class GetOneLessonMapper : Profile
{
    public GetOneLessonMapper()
    {
        CreateMap<Lesson, GetOneLessonResponse>();
    }
}
