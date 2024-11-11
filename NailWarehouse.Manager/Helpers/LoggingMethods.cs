using System;
using Microsoft.Extensions.Logging;
using NailWarehouse.Models;

namespace NailWarehouse.Manager.Helpers
{
    /// <summary>
    /// Методы для логирования
    /// </summary>
    static internal class LoggingMethods
    {
        /// <summary>
        /// Залогировать ошибку при действии с гвоздём
        /// </summary>
        public static void LogErrorNail(ILogger logger, string actionName, Guid nailId, long msElapsed, string errorMessage, Nail nail = null)
        {
            logger.LogError(
                "COULD NOT Complete {ACTION} for nail with ID {ID} and data {@NAIL};" +
                " time elapsed: {ELAPSEDMS} ms; date {DATE}; error message: {ERROR}",
                actionName,
                nailId,
                nail,
                msElapsed,
                DateTime.Now,
                errorMessage
                );
        }

        /// <summary>
        /// Залогировать информацию о действии с гвоздём
        /// </summary>
        public static void LogInfoNail(ILogger logger, string actionName, Guid nailId, long msElapsed, Nail nail = null)
        {
            logger.LogInformation(
                "Completed {ACTION} for nail with ID {ID} and data {@NAIL};" +
                " time elapsed: {ELAPSEDMS} ms; date {DATE};",
                actionName,
                nailId,
                nail,
                msElapsed,
                DateTime.Now
                );
        }

        /// <summary>
        /// Залогировать ошибку
        /// </summary>
        public static void LogError(ILogger logger, string actionName, string errorMessage)
        {
            logger.LogError("COULD NOT complete {ACTION}; date: {DATE}; error: {ERROR}",
                actionName, DateTime.Now, errorMessage);
        }
    }
}
