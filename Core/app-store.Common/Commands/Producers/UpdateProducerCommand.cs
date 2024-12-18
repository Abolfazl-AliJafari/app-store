using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Producers
{
    public record UpdateProducerCommand(
        Guid Id,
        string Title,
        string Description) : IRequest<Result>;
}
