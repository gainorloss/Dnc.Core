using Dnc.Seedwork;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public class EfCoreDbContext
        : DbContext, IApplicationDbContext
    {
        #region Ctor.
        protected EfCoreDbContext()
        { }

        public EfCoreDbContext(DbContextOptions options)
            : base(options)
        { }
        #endregion

        #region Overrides.
        public override int SaveChanges()
        {
            var affectedRows = 0;
            try
            {
                affectedRows = base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedRows;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var affectedRows = 0;
            try
            {
                affectedRows = await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedRows;
        }
        #endregion

        public IQueryable<T> Queryable<T>() where T : class => Set<T>() as IQueryable<T>;

        public T Insert<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Add(entity).Entity;
        }

        public void InsertRange<T>(params T[] entities) where T : class
        {
            if (entities == null || entities.Any())
                throw new ArgumentNullException(nameof(entities));

            AddRange(entities);
        }

        void IApplicationDbContext.Update<T>(T entity)
        { }

        public void Delete<T>(T entity) where T : class => Remove(entity);

        public int BatchUpdate<T>(Expression<Func<T, T>> updateFactory) where T : class => Queryable<T>().BatchUpdate(updateFactory);

        public int BatchDelete<T>(int batchSize = 1000) where T : class => Queryable<T>().BatchDelete(batchSize);

        public async Task<T> InsertAsync<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return (await AddAsync(entity)).Entity;
        }

        public async Task InsertRangeAsync<T>(params T[] entities) where T : class
        {
            if (entities == null || entities.Any())
                throw new ArgumentNullException(nameof(entities));

            await AddRangeAsync(entities);
        }

        public Task UpdateAsync<T>(T entity) where T : class => Task.CompletedTask;
    }
}
