using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace app_store.Domain.Utilities
{
    public static class Validations
    {
        #region Methods

        /// <summary>
        /// check word language entered
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result CheckPersianLanguage(string fieldName, string value)
        {
            if (!Regex.IsMatch(value, "^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]+$"))
            {
                return Result.Failure(ValidationsExceptions.InvalidLanguage(fieldName,ValidationLanguage.Persian));
            }
            return Result.Success();
        }
        public static Result CheckEnglishLanguage(string fieldName, string value)
        {
            if (!Regex.IsMatch(value, "^[\u0000-\u007F]+$"))
            {
                return Result.Failure(ValidationsExceptions.InvalidLanguage(fieldName, ValidationLanguage.English));
            }
            return Result.Success();
        }

        public static Result CheckWhiteSpaceOrEmpty(string fieldName, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new Result(false, ValidationsExceptions.NullOrEmpty(fieldName));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return new Result(false, ValidationsExceptions.NullOrWhiteSpace(fieldName));
            }
            return new Result(true);
        }
        public static Result CheckLengthNumber(string fieldName, int length, string value)
        {
            if (value.Length != length)
            {
                return Result.Failure($"");
            }
            return Result.Success();
        }

        public static Result CheckLengthNumber(string fieldName, int length, string value, LengthValidationMode mode)
        {
            if (mode == LengthValidationMode.Less)
            {
                if (value.Length < length)
                {
                    return Result.Failure(ValidationsExceptions.LengthNumberLess(fieldName,length));
                }
                return Result.Success();
            }

            if (value.Length > length)
            {
                return Result.Failure(ValidationsExceptions.LengthNumberMore(fieldName, length));
            }
            return Result.Success();
        }
        /// <summary>
        /// check a phone number entered format
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        public static Result CheckValidFormatPhoneNumber(string fieldName, string value, bool isMobile = false)
        {
            if (isMobile)
            {
                if (!Regex.IsMatch(value, ("^09[0-9]{9}$")))
                {
                    return Result.Failure(ValidationsExceptions.InvalidFormat(fieldName));
                }
            }
            else
            {
                if (!Regex.IsMatch(value, ("^0[0-9]{10}$")))
                {
                    return Result.Failure(ValidationsExceptions.InvalidFormat(fieldName));
                }
            }
            return Result.Success();
        }

        /// <summary>
        /// check national code entered format
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result CheckValidFormatNationalCode(string fieldName, string value)
        {
            if (!Regex.IsMatch(value, "^[0-9]{10}$"))
            {
                return Result.Failure(ValidationsExceptions.InvalidFormat(fieldName));
            }
            return Result.Success();
        }
        public static Result CheckJustCharacter(string fieldName,string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return Result.Failure(ValidationsExceptions.JustCharacter(fieldName));
            }
            return Result.Success();
        }

        public static Result CheckFileExist(string fieldName,string fileName)
        {
            if(File.Exists(fileName))
            {
                return Result.Success();
            }
            return Result.Failure(ValidationsExceptions.FileDoesNotExist(fieldName,fileName));
        }
        #endregion
    }
}
