using app_store.Domain.Interfaces;
using app_store.Infrastructure.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace app_store.Infrastructure.SqlServer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        protected readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Ctors
        public GenericRepository(AppStoreDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        #endregion

        #region Methods
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity,cancellationToken);
        }

        public async Task DeleteByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                _dbSet.Remove(entityToDelete);
            }
        }
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity,
            bool>>? filter = null,
            bool tracked = true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();

             }
            
            return await query.ToListAsync();
        }

        public void Update(TEntity entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _dbSet.Update(entity);
        }
        #endregion
    }
}
