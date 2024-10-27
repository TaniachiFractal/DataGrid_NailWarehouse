using Microsoft.Extensions.Logging;
using System;

namespace NailWarehouse.Manager.Helpers
{
    /// <summary>
    /// Методы для логирования
    /// </summary>
    static internal class LoggingMethods
    {
        private const string InfoLoggerTemplateNail =
            "Completed {0} for nail with ID {1} and name \"{2}\", time elapsed: {3} ms; date: {4}";
        private const string ErrorLoggerTemplateNail =
            "COULD NOT Complete {0} for nail with ID {1} and name \"{2}\", time elapsed: {3} ms; date: {4}; error message: {5}";
        private const string ErrorLoggerTemplateCommon =
            "COULD NOT Complete {0}, date: {1}; error message: {2}";

        /// <summary>
        /// Залогировать информацию о действии с гвоздём
        /// </summary>
        public static void LogErrorNail(ILogger logger, string actionName, Guid nailId, long msElapsed, string errorMessage, string nailName = null)
        {
            logger.LogError(
                string.Format(
                              ErrorLoggerTemplateNail,
                              actionName,
                              nailId,
                              nailName ?? "-",
                              msElapsed,
                              DateTime.Now,
                              errorMessage
                             )
                );
        }

        /// <summary>
        /// Залогировать ошибку при действии с гвоздём
        /// </summary>
        public static void LogInfoNail(ILogger logger, string actionName, Guid nailId, long msElapsed, string nailName = null)
        {
            logger.LogInformation(
                string.Format(
                              InfoLoggerTemplateNail,
                              actionName,
                              nailId,
                              nailName ?? "-",
                              msElapsed,
                              DateTime.Now
                             )
                );
        }

        /// <summary>
        /// Залогировать ошибку
        /// </summary>
        public static void LogError(ILogger logger, string actionName, string errorMessage)
        {
            logger.LogError(string.Format(
                                          ErrorLoggerTemplateCommon,
                                          actionName,
                                          DateTime.Now,
                                          errorMessage
                                         )
                );
        }
    }
}
