using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookHaven.DAL
{
    public interface IDatabaseHelper
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        int ExecuteNonQuery(string query, SqlParameter[] parameters, SqlTransaction? transaction = null);
        DataTable ExecuteQuery(string query, SqlParameter[] parameters, SqlTransaction? transaction = null);
        object ExecuteScalar(string query, SqlParameter[] parameters, SqlTransaction? transaction = null);
        bool TestConnection();
    }
}
