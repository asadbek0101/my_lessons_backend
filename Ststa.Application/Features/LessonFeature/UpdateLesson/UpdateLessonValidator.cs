using FluentValidation;

namespace Ststa.Application.Features.LessonFeature.UpdateLesson;

public sealed class UpdateLessonValidator : AbstractValidator<UpdateLessonRequest>
{
    public UpdateLessonValidator()
    {
        RuleFor(x=>x.Id).NotEmpty();
        RuleFor(x => x.LessonTitle).NotEmpty().MaximumLength(100000);
        RuleFor(x => x.LessonNumber).NotEmpty().MinimumLength(1).MaximumLength(10);
    }
}
