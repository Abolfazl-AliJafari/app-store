using app_store.Common.Commands.Apps;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Apps.CreateApp
{
    public class CreateAppCommandValidator : AbstractValidator<CreateAppCommand>
    {
        public CreateAppCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Title"))
                .MaximumLength(80).WithMessage(ValidationsExceptions.LengthNumberMore("Title", 80));
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage(ValidationsExceptions.LengthNumberMore("Description", 500));
        }
    }
}
