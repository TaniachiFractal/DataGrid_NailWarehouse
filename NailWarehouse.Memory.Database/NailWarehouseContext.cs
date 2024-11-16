using System.Data.Entity;
using NailWarehouse.Models;

namespace NailWarehouse.Memory.Database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class NailWarehouseContext : DbContext
    {
        public NailWarehouseContext() : base("NailWarehouseDB")
        {
        }

        public DbSet<Nail> Nails { get; set; }
    }
}
