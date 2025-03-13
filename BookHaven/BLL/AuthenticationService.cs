using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Utilities;
using BookHaven.Helpers;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class AuthenticationService
    {
        private readonly UserRepository _userRepo;

        public AuthenticationService()
        {
            _userRepo = new UserRepository();
        }

        public bool AuthenticateUser(string username, string password, out User user)
        {
            user = null;
            try
            {
                user = _userRepo.GetUserByUsername(username);
                if (user == null || !PasswordHelper.VerifyPassword(password, user.Password))
                {
                    return false;
                }

                LoggedInUserSession.SetUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Authentication failed for user '{username}': {ex.Message}");
                return false;
            }
            return false;
        }

        public void Logout()
        {
            LoggedInUserSession.Logout();
        }
    }
}
