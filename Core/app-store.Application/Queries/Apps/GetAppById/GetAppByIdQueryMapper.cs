using app_store.Common.Queries.Apps.GetAppById;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.Apps.GetAppById
{
    public class GetAppByIdQueryMapper
    {
        public static GetAppByIdResponse Map(App app)
        {
            return new GetAppByIdResponse
            {
                Id = app.Id,
                Title = app.Title,
                Description = app.Description,
                PhotosGallery = app.PhotosGallery,
                IconId = app.IconId,
                ProducerId = app.ProducerId,
                AppFileId = app.AppFileId,
                CategoryId = app.CategoryId,
            };
        }
    }
}
