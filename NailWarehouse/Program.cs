using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using NailWarehouse.Forms;
using NailWarehouse.Manager;
using NailWarehouse.Memory;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var storage = new MemoryNailStorage();
            var manager = new NailManager(storage, logger);

            Application.Run(new MainForm(manager));
        }
    }
}
