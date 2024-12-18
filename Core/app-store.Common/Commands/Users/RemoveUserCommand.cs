using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Users
{
    public record RemoveUserCommand(
        Guid Id) : IRequest<Result>;
}
