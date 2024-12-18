using System.Linq.Expressions;

namespace app_store.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity,CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>?> GetAllAsync(
            CancellationToken cancellationToken,
            Expression<Func<T, bool>>? filter = null,
            bool tracked = true);
        void Update(T entity, CancellationToken cancellationToken);
        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
