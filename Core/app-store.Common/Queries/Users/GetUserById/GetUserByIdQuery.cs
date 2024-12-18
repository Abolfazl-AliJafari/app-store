using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Users.GetUserById
{
    public record GetUserByIdQuery(
        Guid Id) : IRequest<Result<GetUserByIdResponse>>;
}
