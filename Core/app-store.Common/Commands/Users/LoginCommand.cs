using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Users
{
    public record LoginCommand(
        string UserName,
        string Password) : IRequest<Result<bool>>;
}
