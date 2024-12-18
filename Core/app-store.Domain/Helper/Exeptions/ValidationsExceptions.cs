using app_store.Domain.Enumerations;

namespace app_store.Domain.Helper.Exeptions
{
    public class ValidationsExceptions
    {
        public static string InvalidLanguage(string fieldName, ValidationLanguage language)
            => new($"{fieldName} language just can be {language}.");
        public static string NullOrEmpty(string fieldName)
            => new($"{fieldName} Cannot be a null or empty.");
        public static string NullOrWhiteSpace(string fieldName)
            => new($"{fieldName} Cannot be a null or white space.");
        public static string LengthNumberEqual(string fieldName, int length)
            => new($"The {fieldName} must be entered with the correct length. => Correct length: {length}.");
        public static string LengthNumberMore(string fieldName, int length)
            => new($"The {fieldName} must be entered with length less than {length}");
        public static string LengthNumberLess(string fieldName, int length)
            => new($"The {fieldName} must be entered with length more than {length}");
        public static string InvalidFormat(string fieldName)
            => new($"Pleaze enter {fieldName} with correct format.");
        public static string JustCharacter(string fieldName)
            => new($"{fieldName} just can contains characters");
        public static string FileDoesNotExist(string fieldName,string fileName)
            => new ($"({fieldName})=>{fileName} does not exist.");
    }
}
