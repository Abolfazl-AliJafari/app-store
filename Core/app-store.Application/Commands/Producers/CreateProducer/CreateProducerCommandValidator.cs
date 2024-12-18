using app_store.Common.Commands.Producers;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Producers.CreateProducer
{
    public class CreateProducerCommandValidator : AbstractValidator<CreateProducerCommand>
    {
        public CreateProducerCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Title"))
                .MaximumLength(50).WithMessage(ValidationsExceptions.LengthNumberMore("Title", 50));
            RuleFor(x => x.Description)
               .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Description"))
               .MaximumLength(500).WithMessage(ValidationsExceptions.LengthNumberMore("Description", 500));
            RuleFor(x => x.Email)
               .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Email"))
               .MaximumLength(200).WithMessage(ValidationsExceptions.LengthNumberMore("Email", 200));


        }
    }
}
