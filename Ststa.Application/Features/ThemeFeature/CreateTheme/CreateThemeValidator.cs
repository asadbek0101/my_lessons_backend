using FluentValidation;

namespace Ststa.Application.Features.ThemeFeature.CreateTheme;

public sealed class CreateThemeValidator : AbstractValidator<CreateThemeRequest>
{
    public CreateThemeValidator()
    {
        RuleFor(x => x.LessonId).NotEmpty();
        RuleFor(x => x.Type).NotEmpty().MinimumLength(1).MaximumLength(10);
    }
}
