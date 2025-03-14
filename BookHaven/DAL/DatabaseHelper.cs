using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using BookHaven.Utilities;

namespace BookHaven.DAL
{
    class DatabaseHelper: IDatabaseHelper
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public DatabaseHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookHavenDB"].ConnectionString;
        }

        public SqlConnection GetConnection(SqlTransaction? transaction = null)
        {
            if (transaction != null)
            {
                return transaction.Connection;
            }

            if (_connection == null || _connection?.State == ConnectionState.Closed)
            {
                _connection = new SqlConnection(_connectionString);
            }

            return _connection;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
            if (_connection != null)
            {
                if (_connection?.State == ConnectionState.Open)
                {
                    _connection?.Close();
                }
                _connection?.Dispose();
                _connection = null;
            }
        }

        public void BeginTransaction()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (Exception ex)
            {
                Logger.LogError("CommitTransaction failed: " + ex.Message);
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (Exception ex)
            {
                Logger.LogError("RollbackTransaction failed: " + ex.Message);
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        private T ExecuteCommand<T>(string query, SqlParameter[] parameters, SqlTransaction transaction, Func<SqlCommand, T> commandAction)
        {
            try
            {
                using (SqlConnection conn = GetConnection(transaction))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddRange(parameters);
                        return commandAction(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"ExecuteCommand failed: {ex.Message} - Query: {query}");
                throw;
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters, SqlTransaction? transaction = null)
        {
            return ExecuteCommand(query, parameters, transaction, cmd => cmd.ExecuteNonQuery());
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters, SqlTransaction? transaction = null)
        {
            return ExecuteCommand(query, parameters, transaction, cmd =>
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            });
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters, SqlTransaction? transaction = null)
        {
            return ExecuteCommand(query, parameters, transaction, cmd => cmd.ExecuteScalar());
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Database connection failed: " + ex.Message);
                return false;
            }
        }
    }
}
