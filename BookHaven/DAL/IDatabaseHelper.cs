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
        int ExecuteNonQuery(string query, SqlParameter[] parameters);
        DataTable ExecuteQuery(string query, SqlParameter[] parameters);
        bool TestConnection();
    }
}
