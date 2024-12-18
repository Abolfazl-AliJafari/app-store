using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.FileStorages
{
    public record RemoveFileStorageCommand(
        Guid Id) : IRequest<Result>;
}
