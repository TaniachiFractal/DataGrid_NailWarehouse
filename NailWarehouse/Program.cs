using System;
using System.Windows.Forms;
using NailWarehouse.Manager;
using NailWarehouse.Memory;
using NailWarehouse.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var storage = new MemoryNailStorage();
            var manager = new NailManager(storage);
            Application.Run(new MainForm(manager));
        }
    }
}
