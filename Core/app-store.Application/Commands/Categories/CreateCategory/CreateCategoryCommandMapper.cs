using app_store.Common.Commands.Categories;
using app_store.Domain.Entities;

namespace app_store.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandMapper
    {
        public static Category Map(CreateCategoryCommand command)
        {
            return new Category(
                command.Title,
                command.MainCategoryId);
        }
    }
}
