using app_store.Common.Commands.Users;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("FirstName"))
                .MaximumLength(50).WithMessage(ValidationsExceptions.LengthNumberMore("FirstName", 50));
            RuleFor(x => x.LastName)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("LastName"))
                .MaximumLength(50).WithMessage(ValidationsExceptions.LengthNumberMore("LastName", 50));
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("UserName"))
                .MaximumLength(40).WithMessage(ValidationsExceptions.LengthNumberMore("UserName", 40));
            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Password"))
                .MaximumLength(32).WithMessage(ValidationsExceptions.LengthNumberMore("Password", 32));
            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Email"))
                .MaximumLength(200).WithMessage(ValidationsExceptions.LengthNumberMore("Email", 200));
        }
    }
}
