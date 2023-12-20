using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.LessonFeature.CreateLesson;

public class CreateLessonMapper : Profile
{
    public CreateLessonMapper()
    {
        CreateMap<CreateLessonRequest, Lesson>();
        CreateMap<Lesson, CreateLessonResponse>();
    }
}
