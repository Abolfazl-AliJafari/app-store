using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.FileStorages
{
    public record CreateFileStorageCommand(
        string FileName,
        string ContentType,
        long FileSize,
        FileStorageProvider[] Providers,
        Stream FileStream) : IRequest<Result<Guid>>;
}
