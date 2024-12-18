using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Users.GetUserAll
{
    public record GetUserAllQuery() : IRequest<Result<IEnumerable<GetUserAllResponse>>>;
}
