using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Models;
using BookHaven.Enums;

namespace BookHaven.Helpers
{
    class LoggedInUserSession
    {
        // Holds the currently logged-in user's data.
        private static User _currentUser;

        // Property to get the current logged-in user
        public static User CurrentUser
        {
            get { return _currentUser; }
        }

        // Sets the logged-in user's information
        public static void SetUser(User user)
        {
            _currentUser = user;
            TriggerLoginEvent();
        }

        // Clears the logged-in user's information (log out)
        public static void Logout()
        {
            _currentUser = null;
            TriggerLogoutEvent();
        }

        // Checks if a user is logged in
        public static bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        // Gets the user's role (if logged in)
        public static string? GetUserRole()
        {
            return _currentUser?.Role.ToString();
        }

        // Checks if the logged-in user has the given role
        public static bool HasRole(UserRole role)
        {
            return _currentUser?.Role == role;
        }

        // Optional events that can be subscribed to for login/logout actions
        public static event Action OnUserLoggedIn;
        public static event Action OnUserLoggedOut;

        // Method to trigger the login event
        private static void TriggerLoginEvent()
        {
            OnUserLoggedIn?.Invoke();
        }

        // Method to trigger the logout event
        private static void TriggerLogoutEvent()
        {
            OnUserLoggedOut?.Invoke();
        }
    }
}
