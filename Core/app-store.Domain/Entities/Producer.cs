using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Utilities;

namespace app_store.Domain.Entities
{
    public class Producer
    {
        #region Ctors
        public Producer() { }
        public Producer(
            string title,
            string description,
            string email)
        {
            var result = Validate(title, description);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            Description = description;
            Email = email;
        }
        #endregion

        #region Props
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Email { get; private set; }
        public virtual ICollection<App>? Apps { get; set; }
        #endregion

        #region Methods
        public void Update(
            string title,
            string description)
        {
            var result = Validate(title, description);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            Description = description;
        }
        #region Validations

        private Result Validate(
            string title,
            string description)
        {
            var resultValidateTitle = ValidateTitle(title);
            if (!resultValidateTitle.IsSuccess)
            {
                return Result.Failure(resultValidateTitle.Message);
            }
            var resultValidateDesc = ValidateDescription(description);
            if (!resultValidateDesc.IsSuccess)
            {
                return Result.Failure(resultValidateDesc.Message);
            }
            return Result.Success();
        }

        private Result ValidateTitle(string title)
        {
            if (title != null)
            {
                var resultValidate2 = Validations.CheckLengthNumber(nameof(Title), 50, title, LengthValidationMode.More);
                if (!resultValidate2.IsSuccess)
                {
                    return Result.Failure(resultValidate2.Message);
                }

                var resultValidate3 = Validations.CheckWhiteSpaceOrEmpty(nameof(Title), title);
                if (!resultValidate3.IsSuccess)
                {
                    return Result.Failure(resultValidate3.Message);
                }
                return Result.Success();
            }
            return Result.Failure("Title can not be null.");
        }
        private Result ValidateDescription(string desc)
        {
            var resultValidate1 = Validations.CheckLengthNumber(nameof(Description), 500, desc, LengthValidationMode.More);
            if (!resultValidate1.IsSuccess)
            {
                return Result.Failure(resultValidate1.Message);
            }
            return Result.Success();
        }
        #endregion
        #endregion
    }
}
