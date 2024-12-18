using app_store.Domain.Entities.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    public class UserNameToString : ValueConverter<UserName,string>
    {
        public UserNameToString()
            :base(x => x.Value,
                 x => new UserName(x))
        {

        }
    }
}
