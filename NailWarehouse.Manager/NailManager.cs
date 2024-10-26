using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;

namespace NailWarehouse.Manager
{
    /// <inheritdoc cref="INailManager"/>
    public class NailManager : INailManager
    {
        private const decimal Tax = 0.2M;
        private readonly INailStorage nailStorage;

        /// <summary>
        /// Конструктор
        /// </summary>
        public NailManager(INailStorage nailStorage)
        {
            this.nailStorage = nailStorage;
        }

        async Task<Nail> INailManager.AddAsync(Nail person)
        {
            var result = await nailStorage.AddAsync(person);
            return result;
        }

        async Task<bool> INailManager.DeleteAsync(Guid id)
        {
            var result = await nailStorage.DeleteAsync(id);
            return result;
        }

        Task INailManager.EditAsync(Nail person)
            => nailStorage.EditAsync(person);

        Task<IReadOnlyCollection<Nail>> INailManager.GetAllAsync()
             => nailStorage.GetAllAsync();

        async Task<INailStats> INailManager.GetStatsAsync()
        {
            var result = await nailStorage.GetAllAsync();
            return new NailStats
            {
                FullCount = result.Count,
                FullSummaryNoTax = result.Sum(nail => nail.Price * nail.Count),
                FullSummaryWithTax = result.Sum(nail => (nail.Price + (nail.Price * Tax)) * nail.Count),
            };
        }
    }
}
