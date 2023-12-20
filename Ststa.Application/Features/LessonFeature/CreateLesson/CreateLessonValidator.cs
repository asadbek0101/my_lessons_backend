
using FluentValidation;

namespace Ststa.Application.Features.LessonFeature.CreateLesson;

public sealed class CreateLessonValidator : AbstractValidator<CreateLessonRequest>
{
    public CreateLessonValidator()
    {
        RuleFor(x => x.LessonTitle).NotEmpty().MaximumLength(10000);
        RuleFor(x => x.LessonNumber).NotEmpty().MinimumLength(1).MaximumLength(4);
    }
}
