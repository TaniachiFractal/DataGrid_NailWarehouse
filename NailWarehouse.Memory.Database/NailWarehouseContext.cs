using System.Data.Entity;
using NailWarehouse.Models;

namespace NailWarehouse.Memory.Database
{
    public class NailWarehouseContext : DbContext
    {
        public DbSet<Nail> Nails { get; set; }
    }
}
