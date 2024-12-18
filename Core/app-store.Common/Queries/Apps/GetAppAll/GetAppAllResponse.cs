namespace app_store.Common.Queries.Apps.GetAppAll
{
    public class GetAppAllResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid IconId{ get; set; }
        public Guid CategoryId { get; set; }
    }
}
