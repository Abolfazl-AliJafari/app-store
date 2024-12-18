using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using app_store.Domain.Interfaces;
using app_store.Infrastructure.SqlServer.DbContexts;

namespace app_store.Infrastructure.SqlServer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppStoreDbContext appStoreDbContext)
            :base(appStoreDbContext) 
        {
            
        }

        public Result<bool> Login(string username, string password)
        {
            var user = _dbSet.Where(x => x.UserName == username).SingleOrDefault();
            if(user == null)
            {
                return Result<bool>.Failure($"User with {username} username was not found.",false);
            }
            if(user.Password != password)
            {
                return Result<bool>.Failure("Password is wrong.",false);
            }
            return Result<bool>.Success("Login succeeded.", true);
        }
    }
}
