using AdmissionCommittee.BL;
using Serilog;
using Serilog.Extensions.Logging;
using AdmissionCommittee.Storage.Sql;
using System.Configuration;
using Microsoft.Extensions.Logging;

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

            var microsoftLoggerFactory = new SerilogLoggerFactory(logger);
            var entrantManagerLogger = microsoftLoggerFactory.CreateLogger<EntrantManager>();

            var connectionString = ConfigurationManager.ConnectionStrings["AdmissionCommitteeConnectionString"]?.ConnectionString;

            var storage = new AdmissionCommitteeStorage(connectionString);
            var manager = new EntrantManager(storage, entrantManagerLogger);

            Application.Run(new Form1(manager));
        }
    }
}