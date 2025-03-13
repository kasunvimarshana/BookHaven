using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookHaven.Utilities
{
    class Logger
    {
        private static readonly string logFilePath = "error_log.txt";

        public static void LogError(string message)
        {
            try
            {
                string logMessage = $"{DateTime.Now}: {message}\n";
                File.AppendAllText(logFilePath, logMessage);
            }
            catch
            {
                // Avoid recursive logging failure.
            }
        }
    }
}
