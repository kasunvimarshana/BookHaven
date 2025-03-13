using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BookHaven.Utilities
{
    class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                String hashedPassword;
                StringBuilder builder = new StringBuilder();
                // hashedPassword = Convert.ToBase64String(bytes);
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                hashedPassword = builder.ToString();
                return hashedPassword;
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            return HashPassword(inputPassword) == storedHash;
        }
    }
}
