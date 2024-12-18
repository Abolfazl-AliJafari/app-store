using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Categories
{
    public record UpdateCategoryCommand(
        Guid Id,
        string Title,
        Guid? MainCategoryId) : IRequest<Result>;
}
