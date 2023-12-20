
using AutoMapper;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.LessonFeature.UpdateLesson;

public class UpdateLessonMapper : Profile
{
    public UpdateLessonMapper()
    {
        CreateMap<UpdateLessonRequest, Lesson>();
        CreateMap<Lesson, UpdateLessonResponse>();
    }
}
