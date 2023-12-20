using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.LessonFeature.GetAllLesson;

public class GetAllLessonMapper : Profile
{
    public GetAllLessonMapper()
    {
        CreateMap<Lesson, GetAllLessonResponse>();
    }
}
