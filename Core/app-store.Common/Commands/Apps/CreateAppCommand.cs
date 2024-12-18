using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Apps
{
    public record CreateAppCommand(
        string Title,
        string Description,
        Guid[]? PhotosGallery,
        Guid IconId,
        Guid ProducerId,
        Guid AppFileId,
        Guid CategoryId) : IRequest<Result<Guid>>;
}
