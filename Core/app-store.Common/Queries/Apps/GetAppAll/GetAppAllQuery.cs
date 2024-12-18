using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Apps.GetAppAll
{
    public record GetAppAllQuery() : IRequest<Result<IEnumerable<GetAppAllResponse>>>;
}
