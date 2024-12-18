using app_store.Common.Queries.Categories.GetCategoryById;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryMapper
    {
        public static GetCategoryByIdResponse Map(Category category)
        {
            return new GetCategoryByIdResponse
            {
                Id = category.Id,
                Title = category.Title,
                MainCategoryId = category.MainCategoryId,
            };
        }
    }
}
