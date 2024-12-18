using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace app_store.Infrastructure.SqlServer.Conversions
{
    internal class GuidArrayToString : ValueConverter<Guid[], string>
    {
        public GuidArrayToString()
            : base(v => string.Join(',', v),
            v => v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToArray())
        {
        }
    }
}
