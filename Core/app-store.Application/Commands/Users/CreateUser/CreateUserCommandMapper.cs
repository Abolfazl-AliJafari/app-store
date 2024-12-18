using app_store.Common.Commands.Users;
using app_store.Domain.Entities.Users;

namespace app_store.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandMapper
    {
        public static User Map(CreateUserCommand command)
        {
            return new User(
                command.FirstName,
                command.LastName,
                command.UserName,
                command.Password,
                command.Email);
        }
    }
}
