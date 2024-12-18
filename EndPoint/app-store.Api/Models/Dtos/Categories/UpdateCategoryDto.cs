namespace app_store.Api.Models.Dtos.Categories
{
    public class UpdateCategoryDto
    {
        public string Title { get; set; }
        public Guid MainCategoryId { get; set; }
    }
}
