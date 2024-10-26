using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NailWarehouse.Models.Interfaces
{
    /// <summary>
    /// Хранилище склада гвоздей
    /// </summary>
    public interface INailStorage
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
    }
}
