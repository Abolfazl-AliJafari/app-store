using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.FileStorages
{
    public record UpdateFileStorageCommand(
        Guid Id,
        string FileName,
        string ContentType,
        long FileSize,
        FileStorageProvider[] Providers) : IRequest<Result>;
}
