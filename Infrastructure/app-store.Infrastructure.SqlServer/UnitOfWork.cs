using app_store.Domain.Interfaces;
using app_store.Infrastructure.SqlServer.DbContexts;
using app_store.Infrastructure.SqlServer.Repositories;

namespace app_store.Infrastructure.SqlServer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields
        private readonly AppStoreDbContext _dbContext;
        #endregion
        public IUserRepository UserRepository { get; }
        #region Ctors
        public UnitOfWork(
            AppStoreDbContext appStoreDbContext,
            IUserRepository userRepository)
        {
            UserRepository = userRepository;
            _dbContext = appStoreDbContext;
        }
        #endregion

        #region Methods

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
