using app_store.Common.Queries.FileStorages.GetFileUrlByFileName;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.FileStorages.GetFileUrlByFileName
{
    public class GetFileUrlByFileNameQueryMapper
    {
        public static GetFileUrlByFileNameResponse Map(FileStorage fileStorage,string url)
        {
            return new GetFileUrlByFileNameResponse()
            {
                FileName = fileStorage.FileName,
                Url = url
            };
        }
    }
}
