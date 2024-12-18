namespace app_store.Api.Models.Dtos.Categories
{
    public class AddCategoryDto
    {
        public string Title { get; set; }
        public Guid? MainCategory { get; set; }
    }
}
