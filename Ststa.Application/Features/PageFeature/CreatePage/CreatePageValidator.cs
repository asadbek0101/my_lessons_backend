
using FluentValidation;

namespace Ststa.Application.Features.PageFeature.CreatePage;

internal class CreatePageValidator : AbstractValidator<CreatePageRequest>
{

    public CreatePageValidator()
    {
        RuleFor(x => x.ThemeId).NotEmpty();
        RuleFor(x => x.PageType).NotEmpty().MinimumLength(1).MaximumLength(10);
        RuleFor(x => x.PageDetails).NotEmpty();
    }
}
