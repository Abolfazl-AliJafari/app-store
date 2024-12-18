using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Producers
{
    public record CreateProducerCommand(
        string Title,
        string Description,
        string Email) : IRequest<Result<Guid>>;
}
