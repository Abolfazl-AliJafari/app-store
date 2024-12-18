using app_store.Domain.Entities.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    public class LastNameToString : ValueConverter<LastName,string>
    {
        public LastNameToString()
            : base(x => x.Value,
                 x => new LastName(x))
        {
            
        }
    }
}
