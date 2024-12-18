using app_store.Common.Commands.FileStorages;
using app_store.Domain.Entities;

namespace app_store.Application.Commands.FileStorages.CreateFileStorage
{
    public class CreateFileStorageCommandMapper
    {
        public static FileStorage Map(CreateFileStorageCommand command)
        {
            return new FileStorage(
                command.FileName,
                command.ContentType,
                command.FileSize,
                command.Providers);
        }
    }
}
