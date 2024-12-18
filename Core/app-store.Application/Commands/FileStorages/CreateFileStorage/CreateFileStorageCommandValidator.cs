using app_store.Common.Commands.FileStorages;
using app_store.Domain.Helper.Exeptions;
using FluentValidation;

namespace app_store.Application.Commands.FileStorages.CreateFileStorage
{
    public class CreateFileStorageCommandValidator : AbstractValidator<CreateFileStorageCommand>
    {
        public CreateFileStorageCommandValidator()
        {
            RuleFor(x => x.FileName)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("FileName"))
                .MaximumLength(150).WithMessage(ValidationsExceptions.LengthNumberMore("FileName", 150));

            RuleFor(x => x.ContentType)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("ContentType"))
                .MaximumLength(10).WithMessage(ValidationsExceptions.LengthNumberMore("ContentType", 10));

            RuleFor(x => x.FileSize)
                .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("FileSize"));
            RuleFor(x => x.Providers)
               .NotNull().NotEmpty().WithMessage(ValidationsExceptions.NullOrEmpty("Providers"));
        }

    }
}
