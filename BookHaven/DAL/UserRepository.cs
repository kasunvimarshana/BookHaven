using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;
using BookHaven.Utilities;
using BookHaven.Enums;

namespace BookHaven.DAL
{
    class UserRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public bool CreateUser(User user, SqlTransaction transaction = null)
        {
            try
            {
                string query = "INSERT INTO Users (Username, Password, Role, FullName, Email, CreatedAt) " +
                               "VALUES (@Username, @PasswordHash, @Role, @FullName, @Email, @CreatedAt)";
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", SqlDbType.NVarChar) { Value = user.Username },
                    new SqlParameter("@PasswordHash", SqlDbType.NVarChar) { Value = PasswordHelper.HashPassword(user.Password) },
                    new SqlParameter("@Role", SqlDbType.NVarChar) { Value = user.Role.ToString() },
                    new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = user.FullName },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = user.Email },
                    new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = user.CreatedAt }
                };
                
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateUser failed: " + ex.Message);
                return false;
            }
        }

        public bool UpdateUser(User user, SqlTransaction transaction = null)
        {
            try
            {
                // If the password is provided, we update it, otherwise, we skip updating the password
                string query = "UPDATE Users SET Username = @Username, Role = @Role, FullName = @FullName, Email = @Email" +
                               (string.IsNullOrEmpty(user.Password) ? "" : ", Password = @Password") +
                               " WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = user.Id },
                    new SqlParameter("@Username", SqlDbType.NVarChar) { Value = user.Username },
                    new SqlParameter("@Role", SqlDbType.NVarChar) { Value = user.Role.ToString() },
                    new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = user.FullName },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = user.Email }
                };

                // If a password is provided, hash it and add to parameters
                if (!string.IsNullOrEmpty(user.Password))
                {
                    parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar) { Value = PasswordHelper.HashPassword(user.Password) });
                }
                
                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateUser failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteUser(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteUser failed: " + ex.Message);
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                string query = "SELECT Id, Username, Password, Role, FullName, Email, CreatedAt FROM Users";
                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<User> users = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    users.Add(MapUser(row));
                }
                return users;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllUsers failed: " + ex.Message);
                return new List<User>();
            }
        }

        public User? GetUserById(int id)
        {
            try
            {
                string query = "SELECT Id, Username, Password, Role, FullName, Email, CreatedAt FROM Users WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapUser(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetUserById failed: " + ex.Message);
                return null;
            }
        }

        public User? GetUserByUsername(string username)
        {
            try
            {
                string query = "SELECT Id, Username, Password, Role, FullName, Email, CreatedAt FROM Users WHERE Username = @Username";
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapUser(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetUserByUsername failed: " + ex.Message);
                return null;
            }
        }

        private User MapUser(DataRow row)
        {
            return new User
            {
                Id = Convert.ToInt32(row["Id"]),
                Username = row["Username"].ToString(),
                Password = row["Password"].ToString(),
                // Role = (UserRole)Convert.ToInt32(row["Role"]),
                Role = Enum.TryParse(
                    row["Role"].ToString(),
                    out UserRole role
                ) ? role : throw new Exception("Invalid role in database"),
                FullName = row["FullName"].ToString(),
                Email = row["Email"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
