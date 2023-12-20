using FluentValidation;

namespace Ststa.Application.Features.ImageFeature.CreateImage;

public class CreateImageValidator : AbstractValidator<CreateImageRequest>
{
    public CreateImageValidator()
    {
        RuleFor(x => x.LessonId).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Link).NotEmpty();
    }
}
