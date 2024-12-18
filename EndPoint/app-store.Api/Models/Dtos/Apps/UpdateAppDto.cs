namespace app_store.Api.Models.Dtos.Apps
{
    public class UpdateAppDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid[]? PhotosGallery { get; set; }
        public Guid IconId { get; set; }
        public Guid ProducerId { get; set; }
        public Guid AppFileId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
