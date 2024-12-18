namespace app_store.Common.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
