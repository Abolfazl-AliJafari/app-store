using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Apps.GetAppById
{
    public record GetAppByIdQuery(Guid Id) : IRequest<Result<GetAppByIdResponse>>;
}
