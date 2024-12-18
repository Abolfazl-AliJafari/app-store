using app_store.Common.Commands.Apps;
using app_store.Domain.Entities;

namespace app_store.Application.Commands.Apps.CreateApp
{
    public static class CreateAppCommandMapper
    {
        public static App Map(CreateAppCommand command)
        {
            return new App(
                command.Title,
                command.Description,
                command.PhotosGallery,
                command.IconId,
                command.ProducerId,
                command.AppFileId,
                command.CategoryId);
        }
    }
}
