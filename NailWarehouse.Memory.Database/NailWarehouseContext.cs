using System.Data.Entity;
using NailWarehouse.Models;

namespace NailWarehouse.Memory.Database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class NailWarehouseContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста базы данных
        /// </summary>
        public NailWarehouseContext() : base("NailWarehouseDB")
        {
        }

        /// <summary>
        /// Таблица <see cref="Nail"/> в базе данных
        /// </summary>
        public DbSet<Nail> Nails { get; set; }
    }
}
