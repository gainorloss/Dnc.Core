using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Dnc.Helpers
{
    /// <summary>
    /// Sql bulk copy helper.
    /// </summary>
    public class SqlBulkCopyHelper
    {
        /// <summary>
        /// Update by data table.
        /// </summary>
        /// <param name="sqlConStr"></param>
        /// <param name="dt"></param>
        public static void UpdateByDataTable(string sqlConStr, DataTable dt)
        {
            SqlConnection sqlCon = new SqlConnection(sqlConStr);
            sqlCon.Open();
            SqlTransaction sqlTran = sqlCon.BeginTransaction(); // 开始事务
            SqlBulkCopy sqlBC = new SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, sqlTran);
            sqlBC.DestinationTableName = "SaleInfo";
            sqlBC.BatchSize = 1;
            try
            {
                sqlBC.WriteToServer(dt); //此处报错
                sqlTran.Commit();

            }
            catch (Exception)
            {
                sqlTran.Rollback();
                throw;
            }
            finally
            {
                sqlBC.Close();
                sqlCon.Close();
            }
        }
    }
}
