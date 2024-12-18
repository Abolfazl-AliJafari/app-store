using app_store.Common.Commands.Categories;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Title"))
                .MaximumLength(50).WithMessage(ValidationsExceptions.LengthNumberMore("Title", 50));
                
        }
    }
}
