using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Data
{
    /// <summary>
    /// Db context based on dapper.
    /// </summary>
    public class DapperDbContext
        :IDisposable
    {
        #region Private members.
        private readonly IDbConnection _myConn;
        #endregion

        #region Ctor.
        public DapperDbContext(string connectionString)
        {
            if (_myConn == null)
                _myConn = new SqlConnection(connectionString);
        }
        #endregion

        #region Dispose.
        public void Dispose()
        {
            _myConn.Close();
            _myConn.Dispose();
        } 
        #endregion
    }
}
