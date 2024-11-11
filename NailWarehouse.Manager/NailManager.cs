using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NailWarehouse.Manager.Helpers;
using NailWarehouse.Manager.Models;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;

namespace NailWarehouse.Manager
{
    /// <inheritdoc cref="INailManager"/>
    public class NailManager : INailManager
    {
        private const decimal Tax = 0.2M;
        private readonly INailStorage nailStorage;
        private readonly ILogger logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public NailManager(INailStorage nailStorage, ILogger logger)
        {
            this.nailStorage = nailStorage;
            this.logger = logger;
        }

        async Task<Nail> INailManager.AddAsync(Nail nail)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Nail result;
            try
            {
                result = await nailStorage.AddAsync(nail);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                LoggingMethods.LogErrorNail(
                    logger,
                    nameof(INailManager.AddAsync),
                    nail.Id,
                    stopwatch.ElapsedMilliseconds,
                    ex.Message,
                    nail
                    );
                return null;
            }

            stopwatch.Stop();
            LoggingMethods.LogInfoNail(
                logger,
                nameof(INailManager.AddAsync),
                nail.Id,
                stopwatch.ElapsedMilliseconds,
                nail
                );
            return result;
        }

        async Task<bool> INailManager.DeleteAsync(Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result;
            try
            {
                result = await nailStorage.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                LoggingMethods.LogErrorNail(logger, nameof(INailManager.DeleteAsync),
                         id,
                         stopwatch.ElapsedMilliseconds,
                         ex.Message
                         );
                return false;
            }

            stopwatch.Stop();
            LoggingMethods.LogInfoNail(logger, nameof(INailManager.DeleteAsync),
                    id,
                    stopwatch.ElapsedMilliseconds
                );
            return result;
        }

        async Task INailManager.EditAsync(Nail nail)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                await nailStorage.EditAsync(nail);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                LoggingMethods.LogErrorNail(logger, nameof(INailManager.EditAsync),
                         nail.Id,
                         stopwatch.ElapsedMilliseconds,
                         ex.Message,
                         nail
                         );
            }

            stopwatch.Stop();
            LoggingMethods.LogInfoNail(logger, nameof(INailManager.EditAsync),
                    nail.Id,
                    stopwatch.ElapsedMilliseconds,
                    nail
                );
        }

        async Task<IReadOnlyCollection<Nail>> INailManager.GetAllAsync()
        {
            try
            {
                return await nailStorage.GetAllAsync();
            }
            catch (Exception ex)
            {
                LoggingMethods.LogError(logger, nameof(INailManager.GetAllAsync), ex.Message);
            }
            return null;
        }

        async Task<INailStats> INailManager.GetStatsAsync()
        {
            try
            {
                IReadOnlyCollection<Nail> result = await nailStorage.GetAllAsync();
                return new NailStats
                {
                    FullCount = result.Count,
                    FullSummaryNoTax = result.Sum(nail => nail.Price * nail.Count),
                    FullSummaryWithTax = result.Sum(nail => (nail.Price + (nail.Price * Tax)) * nail.Count),
                };
            }
            catch (Exception ex)
            {
                LoggingMethods.LogError(logger, nameof(INailManager.GetStatsAsync), ex.Message);
            }
            return null;
        }
    }
}
