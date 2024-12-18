using app_store.Domain.Entities;
using app_store.Domain.Enumerations;
using app_store.Domain.Helper;

namespace app_store.Domain.Interfaces
{
    public interface IFileService
    {
        Task<Result<Dictionary<FileStorageProvider, string>>> GetFileUrlsAsync(FileStorage fileStorage);
        Task<Result> UploadFileAsync(FileStorage fileStorage, Stream fileStream, FileStorageProvider provider);
    }
}
