using System;

namespace NailWarehouse.Models
{
    /// <summary>
    /// Генерирует стандартные объекты классов
    /// </summary>
    public static class DataGenerator
    {
        /// <returns><see cref="Nail"/> со стандартными параметрами</returns>
        public static Nail GetDefaultNail() =>
        new Nail()
        {
            Id = Guid.NewGuid(),
            Name = "Без названия",
            Length = 1.0M,
            Material = Material.Copper,
            Count = 10,
            MinCount = 1,
            Price = 100.0M
        };
    }
}
