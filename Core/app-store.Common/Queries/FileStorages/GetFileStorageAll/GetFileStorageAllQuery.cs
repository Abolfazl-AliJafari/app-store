using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.FileStorages.GetFileStorageAll
{
    public record GetFileStorageAllQuery() : IRequest<Result<IEnumerable<GetFileStorageAllResponse>>>;
}
