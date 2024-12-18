using app_store.Common.Queries.Categories.GetCategoryAll;
using app_store.Common.Queries.Users.GetUserAll;
using app_store.Common.Queries.Users.GetUserById;
using app_store.Domain.Entities;
using app_store.Domain.Entities.Users;

namespace app_store.Application.Queries.Categories.GetCategotyAll
{
    public class GetCategoryAllQueryMapper
    {
        public static IEnumerable<GetCategoryAllResponse> Map(IEnumerable<Category> categories)
        {
            List<GetCategoryAllResponse> getCategoryAllResponses = new List<GetCategoryAllResponse>();
            foreach (var category in categories)
            {
                getCategoryAllResponses.Add(new GetCategoryAllResponse
                {
                    Id = category.Id,
                    Title = category.Title,
                });
            }
            return getCategoryAllResponses.AsEnumerable();
        }
    }
}
