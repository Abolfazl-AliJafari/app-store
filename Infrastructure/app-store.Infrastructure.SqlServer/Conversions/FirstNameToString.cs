using app_store.Domain.Entities.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    public class FirstNameToString : ValueConverter<FirstName,string>
    {
        public FirstNameToString()
            :base(x => x.Value,
                 x => new FirstName(x))
        {
            
        }
    }
}
