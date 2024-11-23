using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NailWarehouse.Models.Interfaces
{
    /// <summary>
    /// Прослойка между хранилищем и представлением
    /// </summary>
    public interface INailManager
    {
        /// <summary>
        /// Получение всех данных
        /// </summary>
        Task<IReadOnlyCollection<Nail>> GetAllAsync();

        /// <summary>
        /// Операция добавления
        /// </summary>
        Task<Nail> AddAsync(Nail nail);

        /// <summary>
        /// Операция изменения
        /// </summary>
        Task EditAsync(Nail nail);

        /// <summary>
        /// Операция удаления
        /// </summary>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Получение суммарных данных
        /// </summary>
        Task<INailStats> GetStatsAsync();

        /// <summary>
        /// Получить гвоздь по ID
        /// </summary>
        Task<Nail> GetNailByIdAsync(Guid id);

    }
}
