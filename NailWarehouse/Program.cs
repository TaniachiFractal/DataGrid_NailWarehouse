using System;
using System.Windows.Forms;
using NailWarehouse.Forms;
using NailWarehouse.Manager;
using NailWarehouse.Memory;
using Serilog;
using Serilog.Extensions.Logging;

namespace NailWarehouse
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq("http://localhost:5341", apiKey: "fgySxAGGktcEozAbLtIR")
                .WriteTo.Debug()
                .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger("NailWarehouse");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var storage = new MemoryNailStorage();
            var manager = new NailManager(storage, logger);

            Application.Run(new MainForm(manager));
        }
    }
}
