namespace app_store.Common.Queries.Apps.GetAppById
{
    public class GetAppByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid[]? PhotosGallery { get; set; }
        public Guid IconId { get; set; }
        public Guid ProducerId { get; set; }
        public Guid AppFileId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
