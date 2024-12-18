using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.FileStorages.GetFileStorageById
{
    public record GetFileStorageByIdQuery(
        Guid Id) : IRequest<Result<GetFileStorageByIdResponse>>;
}
