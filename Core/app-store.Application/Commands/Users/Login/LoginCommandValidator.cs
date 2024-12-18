using app_store.Common.Commands.Users;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.Users.Login
{
    internal class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("UserName"))
                .MaximumLength(40).WithMessage(ValidationsExceptions.LengthNumberMore("UserName", 40));
            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Password"))
                .MaximumLength(32).WithMessage(ValidationsExceptions.LengthNumberMore("Password", 32));
        }
    }
}
