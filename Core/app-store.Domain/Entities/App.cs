using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Utilities;

namespace app_store.Domain.Entities
{
    public class App
    {
        #region Ctors
        public App() { }
        public App(
            string title,
            string description,
            Guid[]? photosGallery,
            Guid iconId,
            Guid producerId,
            Guid appFileId,
            Guid categoryId)
        {
            var result = Validate(title, description);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            Description = description;
            PhotosGallery = photosGallery;
            IconId = iconId;
            ProducerId = producerId;
            AppFileId = appFileId;
            CategoryId = categoryId;
        }
        #endregion

        #region Props
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public Guid[]? PhotosGallery { get; private set; }
        public virtual FileStorage Icon { get;  set; }
        public Guid IconId { get; private set; }
        public virtual Producer Producer { get; set; }
        public Guid ProducerId { get; private set; }
        public virtual FileStorage AppFile{ get; set; }
        public Guid AppFileId { get; private set; }
        public virtual Category Category{ get; set; }
        public Guid CategoryId { get; private set; }

        #endregion

        #region Methods
        public void Update(
            string title,
            string description,
            Guid[] photosGallery,
            Guid iconId,
            Guid producerId,
            Guid appFileId,
            Guid categoryId)
        {
            var result = Validate(title, description);
            if (!result.IsSuccess)
            {
                throw new ArgumentException(result.Message);
            }
            Title = title;
            Description = description;
            PhotosGallery = photosGallery;
            IconId = iconId;
            ProducerId = producerId;
            AppFileId = appFileId;
            CategoryId = categoryId;
        }

        #region Validation
        /// <summary>
        /// validate all input fields
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="photos"></param>
        /// <param name="iconUrl"></param>
        /// <param name="producerId"></param>
        /// <returns></returns>
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
            //var resultValidatePhotos = ValidatePhotos(photos);
            //if (!resultValidatePhotos.IsSuccess)
            //{
            //    return Result.Failure(resultValidatePhotos.Message);
            //}
            //var resultValidateIcon = ValidateIcon(iconUrl);
            //if (!resultValidateIcon.IsSuccess)
            //{
            //    return Result.Failure(resultValidateIcon.Message);
            //}
            return Result.Success();
        }

        private Result ValidateTitle(string title)
        {
            if (title != null)
            {

                var resultValidate1 = Validations.CheckJustCharacter(nameof(Title), title);
                if (!resultValidate1.IsSuccess)
                {
                    return Result.Failure(resultValidate1.Message);
                }

                var resultValidate2 = Validations.CheckLengthNumber(nameof(Title), 80, title, LengthValidationMode.More);
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
        //private Result ValidatePhotos(string[] photos)
        //{
        //    foreach (var photo in photos)
        //    {
        //        var result = Validations.CheckFileExist(nameof(PhotosUrl), photo);
        //        if (!result.IsSuccess)
        //        {
        //            return Result.Failure(result.Message);
        //        }
        //    }
        //    return Result.Success();
        //}
        //private Result ValidateIcon(string icon)
        //{
        //    var result = Validations.CheckFileExist(nameof(IconUrl), icon);
        //    if (!result.IsSuccess)
        //    {
        //        return Result.Failure(result.Message);
        //    }
        //    return Result.Success();
        //}
        #endregion

        #endregion
    }
}
