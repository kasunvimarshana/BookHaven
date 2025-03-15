using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BookHaven.Models;
using BookHaven.DAL;
using BookHaven.BLL;
using BookHaven.Enums;
using BookHaven.Utilities;

namespace BookHaven.Seeders
{
    static class UserSeeder
    {
        //
        public static bool EnsureAdminUserExists()
        {
            try
            {
                DatabaseHelper _dbHelper = new DatabaseHelper();
                UserRepository _userRepo = new UserRepository();

                // Check if any Admin user exists
                string query = @"SELECT COUNT(*) FROM Users WHERE Role = @Role";

                SqlParameter[] parameters = {
                    new SqlParameter("@Role", SqlDbType.NVarChar) { Value = UserRole.Admin.ToString() }
                };

                int adminCount = (int)_dbHelper.ExecuteScalar(query, parameters);

                if (adminCount > 0)
                {
                    return true;
                }

                var defaultAdmin = new User
                {
                    Username = "admin",
                    Password = "admin",
                    Role = UserRole.Admin,
                    FullName = "System Administrator",
                    Email = "admin@email.com",
                    CreatedAt = DateTime.Now
                };

                // Insert the default Admin user
                return _userRepo.CreateUser(defaultAdmin);
            }
            catch (Exception ex)
            {
                Logger.LogError("EnsureDefaultAdminExists failed: " + ex.Message);
                return false;
            }
        }
        //
    }
}
