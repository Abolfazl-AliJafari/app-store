using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Categories
{
    public record RemoveCategoryCommand(
        Guid Id) : IRequest<Result>;
}
