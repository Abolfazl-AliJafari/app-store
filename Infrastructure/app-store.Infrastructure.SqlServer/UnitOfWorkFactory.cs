using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_store.Infrastructure.SqlServer.DbContexts;

namespace app_store.Infrastructure.SqlServer
{
    public class UnitOfWorkFactory
    {
        //public UnitOfWorkFactory(IDbContextFactory<AppStoreDbContext> dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        //public UnitOfWork Begin()
        //{
        //    return new UnitOfWork(dbContext.CreateDbContext());
        //}
        //private IDbContextFactory<AppStoreDbContext> dbContext { get; set; }
    }
}
