using app_store.Domain.Enumerations;

namespace app_store.Common.Queries.FileStorages.GetFileStorageById
{
    public class GetFileStorageByIdResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public FileStorageProvider[] Providers { get; set; }
        public Dictionary<FileStorageProvider,string> FileUrls { get; set; }
    }
}
