using app_store.Domain.Enumerations;

namespace app_store.Api.Models.Dtos.FileStorages
{
    public class UpdateFileStorageDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public FileStorageProvider[] Providers { get; set; }
    }
}
