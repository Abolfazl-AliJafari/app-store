using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;

namespace app_store.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Result<bool> Login(string username, string password);
    }
}
