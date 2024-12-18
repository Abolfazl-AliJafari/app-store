using app_store.Domain.Interfaces;

namespace app_store.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IUserRepository UserRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
