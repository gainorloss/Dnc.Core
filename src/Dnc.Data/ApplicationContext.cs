using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public class ApplicationContext: DbContext
    {
        #region Ctor.
        protected ApplicationContext()
        { }

        public ApplicationContext(DbContextOptions options)
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
    }
}
