using app_store.Common.Queries.FileStorages.GetFileStorageById;
using app_store.Domain.Entities;
using app_store.Domain.Enumerations;

namespace app_store.Application.Queries.FileStorages.GetFileStorageById
{
    public class GetFileStorageByIdQueryMapper
    {

        public static GetFileStorageByIdResponse Map(FileStorage fileStorage,Dictionary<FileStorageProvider,string> fileUrl)
        {
            return
                new GetFileStorageByIdResponse
                {
                    Id = fileStorage.Id,
                    FileName = fileStorage.FileName,
                    ContentType = fileStorage.ContentType,
                    FileSize = fileStorage.FileSize,
                    Providers = fileStorage.Providers,
                    FileUrls = fileUrl
                };
        }
    }
}
