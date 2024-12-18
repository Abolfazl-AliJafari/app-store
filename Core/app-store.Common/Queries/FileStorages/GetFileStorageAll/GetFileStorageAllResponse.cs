namespace app_store.Common.Queries.FileStorages.GetFileStorageAll
{
    public class GetFileStorageAllResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }

    }
}
