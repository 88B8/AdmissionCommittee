using AdmissionCommittee.BL;
using AdmissionComittee.Storage.InMemory;

namespace AdmissionCommittee.Desktop
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

            var storage = new EntrantInMemoryStorage();
            var manager = new EntrantManager(storage);

            Application.Run(new Form1(manager));
        }
    }
}