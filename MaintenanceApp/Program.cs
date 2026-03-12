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
            string connectionString =
                "Host=localhost;Username=postgres;Password=12345678;Database=Maintenance";
            // Repository
            IMaintenanceRepository maintenanceRepository =
                new MaintenanceRepository(connectionString);

            // Service
            MaintenanceService maintenanceService =
                new MaintenanceService(maintenanceRepository);

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmSetup(maintenanceService));
        }
    }
}