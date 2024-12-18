using app_store.Common.Queries.Categories.GetCategoryAll;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Categories
{
    public record GetCategoryAllQuery(
        ):IRequest<Result<IEnumerable<GetCategoryAllResponse>>>;
}
