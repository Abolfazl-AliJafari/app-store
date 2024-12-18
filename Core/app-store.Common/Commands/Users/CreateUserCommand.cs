using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Commands.Users
{
    public record CreateUserCommand(
        string FirstName,
        string LastName,
        string UserName,
        string Password,
        string Email) : IRequest<Result<Guid>>;
}
