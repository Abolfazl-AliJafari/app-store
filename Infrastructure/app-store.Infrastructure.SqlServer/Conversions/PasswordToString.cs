using app_store.Domain.Entities.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    public class PasswordToString : ValueConverter<Password,string>
    {
        public PasswordToString()
            :base(x => x.Value,
                 x => new Password(x))
        {
            
        }
    }
}
