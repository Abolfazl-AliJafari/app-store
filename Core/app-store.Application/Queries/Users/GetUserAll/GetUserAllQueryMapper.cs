using app_store.Common.Queries.Users.GetUserAll;
using app_store.Domain.Entities.Users;

namespace app_store.Application.Queries.Users.GetUserAll
{
    public class GetUserAllQueryMapper
    {
        public static IEnumerable<GetUserAllResponse> Map(IEnumerable<User> users) 
        {
            List<GetUserAllResponse> getUserAllResponses = new List<GetUserAllResponse>();
            foreach (var user in users)
            {
                getUserAllResponses.Add(new GetUserAllResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                });
            }
            return getUserAllResponses.AsEnumerable();
        }

    }
}
