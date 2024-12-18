using app_store.Common.Queries.Users.GetUserById;
using app_store.Domain.Entities.Users;

namespace app_store.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryMapper
    {
        public static GetUserByIdResponse Map(User user)
        {
            return
                new GetUserByIdResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                };
        }
    }
}
