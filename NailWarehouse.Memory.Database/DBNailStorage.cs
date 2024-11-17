using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;

namespace NailWarehouse.Memory.Database
{
    /// <summary>
    /// Методы для работы с контекстом базы данных склада гвоздей <see cref="NailWarehouseContext"/>
    /// </summary>
    public class DBNailStorage : INailStorage
    {
        async Task<Nail> INailStorage.AddAsync(Nail nail)
        {
            using (var context = new NailWarehouseContext())
            {
                context.Nails.Add(nail);
                await context.SaveChangesAsync();
            }
            return nail;
        }

        async Task<bool> INailStorage.DeleteAsync(Guid id)
        {
            using (var context = new NailWarehouseContext())
            {
                var item = await context.Nails.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    context.Nails.Remove(item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        async Task INailStorage.EditAsync(Nail nail)
        {
            using (var context = new NailWarehouseContext())
            {
                var item = await context.Nails.FirstOrDefaultAsync(x => x.Id == nail.Id);
                if (item != null)
                {
                    item.Name = nail.Name;
                    item.Length = nail.Length;
                    item.Material = nail.Material;
                    item.Count = nail.Count;
                    item.MinCount = nail.MinCount;
                    item.Price = nail.Price;
                }
                await context.SaveChangesAsync();
            }
        }

        async Task<IReadOnlyCollection<Nail>> INailStorage.GetAllAsync()
        {
            using (var context = new NailWarehouseContext())
            {
                var items = await context.Nails
                    .OrderByDescending(x => x.Price)
                    .ToListAsync()
                    ;
                return items;
            }
        }
    }
}
