using BookHaven.Seeders;

namespace BookHaven
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Ensure the admin user exists before launching the app
            UserSeeder.EnsureAdminUserExists();

            Application.Run(new BookHaven.UI.Forms.LoginForm());
        }
    }
}