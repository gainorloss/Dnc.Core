using Dnc.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public interface IApplicationDbContext : IPlugin
    {
        IQueryable<T> Queryable<T>() where T : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        T Insert<T>(T entity) where T : class;

        void InsertRange<T>(params T[] entities) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        int BatchUpdate<T>(Expression<Func<T, T>> updateFactory) where T : class;

        int BatchDelete<T>(int batchSize = 1000) where T : class;

        Task<T> InsertAsync<T>(T entity) where T : class;

        Task InsertRangeAsync<T>(params T[] entities) where T : class;

        Task UpdateAsync<T>(T entity) where T : class;
    }
}
