using MaintenanceApp.Forms;

using MaintenanceApp.Infrastructure;
using MaintenanceApp.Interfaces;
using MaintenanceApp.Services;

namespace MaintenanceApp
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
            
            string path = Application.StartupPath + "\\AppConfig.ini";
           
            if (!File.Exists(path))
            {
                
                IniFile _ini = new IniFile(path);
                _ini.Write("Database", "Host", "172.28.8.87");
                _ini.Write("Database", "Port", "5432");
                _ini.Write("Database", "User", "postgres");
                _ini.Write("Database", "Password", "12345678");
                _ini.Write("Database", "Database", "Maintenance");
            }
            IniFile ini = new IniFile(path);
            string connectionString = $"Host={ini.Read("Database", "Host")};" +
               $"Port={ini.Read("Database", "Port")};" +
               $"Username={ini.Read("Database", "User")};" +
               $"Password={ini.Read("Database", "Password")};" +
               $"Database={ini.Read("Database", "Database")};";
            // Repository
            IMaintenanceRepository maintenanceRepository =
                new MaintenanceRepository(connectionString);

            // Service
            MaintenanceService maintenanceService =
                new MaintenanceService(maintenanceRepository);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(maintenanceService));
        }
    }
}