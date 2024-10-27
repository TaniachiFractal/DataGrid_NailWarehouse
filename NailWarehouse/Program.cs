using System;
using System.Windows.Forms;
using NailWarehouse.Manager;
using NailWarehouse.Memory;
using NailWarehouse.Forms;
using Microsoft.Extensions.Logging;

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
            var factory = LoggerFactory.Create(builder => builder.AddDebug());
            var logger = factory.CreateLogger("NailWarehouse");
            logger.LogInformation("The app is starting");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var storage = new MemoryNailStorage();
            var manager = new NailManager(storage, logger);

            Application.Run(new MainForm(manager));
        }
    }
}
