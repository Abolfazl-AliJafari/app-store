using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Producers
{
    public record RemoveProducerCommand(
        Guid Id) : IRequest<Result>;
}
