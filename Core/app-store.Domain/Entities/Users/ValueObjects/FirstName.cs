﻿using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Utilities;

namespace app_store.Domain.Entities.Users.ValueObjects
{
    public class FirstName
    {
        #region Ctors

        public FirstName(string value)
        {
            var result = Validate(value);
            if (result.IsSuccess)
                Value = value;
            else
                throw new ArgumentException(result.Message);
        }
        #endregion

        #region Props

        public string Value { get; private set; } = string.Empty;
        #endregion

        #region Methods

        private Result Validate(string value)
        {
            var resultValidate1 = Validations.CheckWhiteSpaceOrEmpty(nameof(FirstName), value);
            if (!resultValidate1.IsSuccess)
                return new Result(false, resultValidate1.Message);
            //var resultValidate2 = Validations.CheckPersianLanguage(nameof(FirstName), value);
            //if (!resultValidate2.IsSuccess)
            //    return new Result(false, resultValidate2.Message);
            var resultValidate3 = Validations.CheckLengthNumber(nameof(FirstName), 50, value, LengthValidationMode.More);
            if (!resultValidate3.IsSuccess)
                return new Result(false, resultValidate3.Message);

            return new Result(true);
        }
        public static implicit operator string(FirstName FirstName)
            => FirstName.Value;
        public static implicit operator FirstName(string Value)
             => new(Value);
        #endregion
    }
}
