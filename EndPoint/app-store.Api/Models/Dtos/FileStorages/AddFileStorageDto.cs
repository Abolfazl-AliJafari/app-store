using app_store.Domain.Enumerations;

namespace app_store.Api.Models.Dtos.FileStorages
{
    public class AddFileStorageDto
    {
        public string FilesName { get; set; }
        public string ContentsType { get; set; }
        public long FileSize { get; set; }
        public FileStorageProvider[] Providers{ get; set; }
        public IFormFile File{ get; set; }
    }
}
