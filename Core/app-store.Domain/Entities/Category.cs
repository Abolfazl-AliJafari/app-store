using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Utilities;

namespace app_store.Domain.Entities
{
    public class Category
    {
        #region Ctors
        public Category() { }
        public Category(
            string title,
            Guid? mainCategoryId)
        {
            var result = Validate(title);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            MainCategoryId = mainCategoryId;
        }
        #endregion

        #region Props
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public ICollection<App> Apps { get; set; }
        public virtual Category? MainCategory { get; set; }
        public virtual ICollection<Category>? SubCategories { get; set; }
        public Guid? MainCategoryId { get; private set; }
        #endregion

        #region Methods
        public void Update(
            string title,
            Guid? mainCategoryId)
        {
            var result = Validate(title);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            MainCategoryId = mainCategoryId;
        }
        public Result Validate(string title)
        {
            var result = ValidateTitle(title);
            if (!result.IsSuccess)
            {
                return Result.Failure(result.Message);
            }
            return Result.Success();
        }

        public Result ValidateTitle(string title)
        {
            if (title != null)
            {

                var resultValidate1 = Validations.CheckJustCharacter(nameof(Title), title);
                if (!resultValidate1.IsSuccess)
                {
                    return Result.Failure(resultValidate1.Message);
                }

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
        #endregion
    }
}
