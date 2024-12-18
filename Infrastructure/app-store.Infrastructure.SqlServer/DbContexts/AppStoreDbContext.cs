using app_store.Domain.Entities;
using app_store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace app_store.Infrastructure.SqlServer.DbContexts
{
    public class AppStoreDbContext : DbContext
    {
        #region Ctors

        public AppStoreDbContext(DbContextOptions<AppStoreDbContext> options)
            : base(options)
        {

        }
        #endregion

        #region Props
        public DbSet<User> Users { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileStorage> FileStorages { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppStoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
