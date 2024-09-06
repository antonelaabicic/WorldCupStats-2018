using DataLayer.Models;
using DataLayer.Repository;

namespace FootballPro
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

            DataManager.Initialize();

            Application.Run(new MainForm());
        }
    }
}