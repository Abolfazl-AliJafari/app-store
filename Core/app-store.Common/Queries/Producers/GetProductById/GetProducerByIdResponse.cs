namespace app_store.Common.Queries.Producers.GetProductById
{
    public class GetProducerByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
