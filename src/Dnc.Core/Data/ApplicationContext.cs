using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dnc.Data
{
    public class ApplicationContext
        : DbContext
    {
        public override int SaveChanges()
        {
            var affectedRows = 0;
            try
            {
                affectedRows = base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }catch(Exception ex)
            {
                throw;
            }
            return affectedRows;
        }
    }
}
