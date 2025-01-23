using FluentValidation;

namespace Store.Application.Features.Categories.Commands.AddCategory;
public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{

    public AddCategoryCommandValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(c => c.Name)
            .NotEmpty();

        RuleFor(x => x.RootCategoryId)
     .Must(x => x == null || x.Value != Guid.Empty)
     .WithMessage("{PropertyName} should be null or a valid Id.");
    }

}
