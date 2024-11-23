using NailWarehouse.Database;
using NailWarehouse.Manager;
using NailWarehouse.Models.Interfaces;
using Serilog;
using Serilog.Extensions.Logging;

namespace NailWarehouse.Web.Models
{
    /// <summary>
    /// Держит состояние объектов, которые использует множество страниц
    /// </summary>
    public static class StaticAppModel
    {
        /// <inheritdoc cref="NailManager"/>
        public static INailManager NailManager { get; set; }

        /// <inheritdoc cref="DBNailStorage"/>
        public static INailStorage DBNailStorage { get; set; }

        /// <inheritdoc cref="ILogger"/>
        public static Microsoft.Extensions.Logging.ILogger Logger { get; set; }

        /// <summary>
        /// ID выбранного гвоздя
        /// </summary>
        public static Guid SelectedNailId { get; set; }

        static StaticAppModel()
        {
            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Debug()
                .CreateLogger();

            Logger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger("NailWarehouse");

            DBNailStorage = new DBNailStorage();
            NailManager = new NailManager(DBNailStorage, Logger);
        }
    }
}
