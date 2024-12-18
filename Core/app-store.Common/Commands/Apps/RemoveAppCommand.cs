using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Apps
{
    public record RemoveAppCommand(Guid Id) : IRequest<Result>;
}
