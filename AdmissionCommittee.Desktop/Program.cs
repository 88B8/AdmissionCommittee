using AdmissionCommittee.BL;
using AdmissionComittee.Storage.InMemory;
using Serilog;
using Serilog.Extensions.Logging;

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

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            Log.Logger = logger;

            var microsoftLogger = new SerilogLoggerFactory(logger)
                .CreateLogger(nameof(Program));

            var storage = new EntrantInMemoryStorage();
            var manager = new EntrantManager(storage, microsoftLogger);

            Application.Run(new Form1(manager));
        }
    }
}