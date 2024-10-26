using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;

namespace NailWarehouse.Memory
{
    /// <inheritdoc cref="INailStorage"/>
    public class MemoryNailStorage : INailStorage
    {
        private readonly List<Nail> nails;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MemoryNailStorage()
        {
            nails = new List<Nail>();
        }

        Task<Nail> INailStorage.AddAsync(Nail nail)
        {
            nails.Add(nail);
            return Task.FromResult(nail);
        }

        Task<bool> INailStorage.DeleteAsync(Guid id)
        {
            var nail = nails.FirstOrDefault(x => x.Id == id);
            if (nail != null)
            {
                nails.Remove(nail);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        Task INailStorage.EditAsync(Nail nail)
        {
            var target = nails.FirstOrDefault(n => n.Id == nail.Id);
            if (nail != null && target != null)
            {
                target.Name = nail.Name;
                target.Length = nail.Length;
                target.Material = nail.Material;
                target.Count = nail.Count;
                target.MinCount = nail.MinCount;
                target.Price = nail.Price;
                return Task.CompletedTask;
            }
            return null;
        }

        Task<IReadOnlyCollection<Nail>> INailStorage.GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Nail>>(nails);

    }
}
