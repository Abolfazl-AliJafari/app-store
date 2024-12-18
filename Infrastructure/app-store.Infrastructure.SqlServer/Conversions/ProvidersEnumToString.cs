using app_store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    internal class ProvidersEnumToString: ValueConverter<FileStorageProvider[], string>
    {
        public ProvidersEnumToString()
         : base(
             v => string.Join(",", v.Select(e => ((int)e).ToString())), 
             v => v.Split(',', StringSplitOptions.None).Select(e => (FileStorageProvider)int.Parse(e)).ToArray()) 
        {
        }
    }
}
