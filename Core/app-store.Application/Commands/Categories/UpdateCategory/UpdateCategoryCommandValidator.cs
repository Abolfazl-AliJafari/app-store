using app_store.Common.Commands.Categories;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {

        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Title"))
                .MaximumLength(50).WithMessage(ValidationsExceptions.LengthNumberMore("Title", 50));

        }
    }
}
