using Microsoft.EntityFrameworkCore;
using System;


namespace Dnc.Data
{
    public class ApplicationDbContext
        : DbContext
    {
        #region Ctor.
        protected ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }
        #endregion

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
            }catch(Exception ex)
            {
                throw ex;
            }
            return affectedRows;
        }
    }
}
