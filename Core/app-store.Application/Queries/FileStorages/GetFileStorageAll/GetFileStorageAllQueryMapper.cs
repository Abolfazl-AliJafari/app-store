using app_store.Common.Queries.FileStorages.GetFileStorageAll;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.FileStorages.GetFileStorageAll
{
    public class GetFileStorageAllQueryMapper
    {
        public static IEnumerable<GetFileStorageAllResponse> Map(IEnumerable<FileStorage> fileStorages)
        {
            List<GetFileStorageAllResponse> getFileStorageAllResponses = new List<GetFileStorageAllResponse>();
            foreach (var fileStorage in fileStorages)
            {
                getFileStorageAllResponses.Add(new GetFileStorageAllResponse
                {
                    Id = fileStorage.Id,
                    FileName = fileStorage.FileName,
                    ContentType = fileStorage.ContentType,
                    FileSize = fileStorage.FileSize,
                });
            }
            return getFileStorageAllResponses.AsEnumerable();
        }
    }
}
