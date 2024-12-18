using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Categories.GetCategoryById
{
    public record GetCategoryByIdQuery(
        Guid Id) : IRequest<Result<GetCategoryByIdResponse>>;
}
