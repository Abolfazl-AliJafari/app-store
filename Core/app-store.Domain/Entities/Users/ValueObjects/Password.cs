using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Utilities;

namespace app_store.Domain.Entities.Users.ValueObjects
{
    public class Password
    {
        #region Ctors

        public Password(string value)
        {
            var result = Validate(value);

            if (result.IsSuccess)
                Value = value;
            else
                throw new ArgumentException(result.Message);
        }
        #endregion

        #region Props

        public string Value { get; set; } = string.Empty;
        #endregion

        #region Methods

        private Result Validate(string value)
        {
            var resultValidate1 = Validations.CheckWhiteSpaceOrEmpty(nameof(Password), value);
            if (!resultValidate1.IsSuccess)
                return new Result(false, resultValidate1.Message);
            var resultValidate2 = Validations.CheckEnglishLanguage(nameof(Password), value);
            if (!resultValidate2.IsSuccess)
                return new Result(false, resultValidate2.Message);
            //check max length
            var resultValidate3 = Validations.CheckLengthNumber(nameof(Password), 32, value, LengthValidationMode.More);
            if (!resultValidate3.IsSuccess)
                return new Result(false, resultValidate3.Message);
            //check min length
            var resultValidate4 = Validations.CheckLengthNumber(nameof(Password), 8, value, LengthValidationMode.Less);
            if (!resultValidate4.IsSuccess)
                return new Result(false, resultValidate4.Message);
            return new Result(true);
        }

        public static implicit operator string(Password Password)
            => Password.Value;
        public static implicit operator Password(string Value)
             => new(Value);
        #endregion
    }
}
