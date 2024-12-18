using app_store.Common.Commands.Apps;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Apps.UpdateApp
{
    public class UpdateAppCommandValidator : AbstractValidator<UpdateAppCommand>
    {
        public UpdateAppCommandValidator()
        {
            RuleFor(x => x.Title)
                   .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Title"))
                   .MaximumLength(80).WithMessage(ValidationsExceptions.LengthNumberMore("Title", 80));
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage(ValidationsExceptions.LengthNumberMore("Description", 500));
        }
    }
}
