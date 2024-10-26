using NailWarehouse.Models;
using NailWarehouse.ValidatableModels;

namespace NailWarehouse.Helpers
{
    /// <summary>
    /// Методы приведения одного типа к другому
    /// </summary>
    public static class Converters
    {
        /// <summary>
        /// Привести <see cref="Nail"/> к <see cref="ValidatableNail"/>
        /// </summary>
        public static ValidatableNail ToValidatableNail(Nail nail)
        {
            return new ValidatableNail()
            {
                Id = nail.Id,
                Name = nail.Name,
                Length = nail.Length,
                Material = nail.Material,
                Count = nail.Count,
                MinCount = nail.MinCount,
                Price = nail.Price,
            };
        }

        /// <summary>
        /// Привести <see cref="ValidatableNail"/> к <see cref="Nail"/>
        /// </summary>
        public static Nail ToNail(ValidatableNail validNail)
        {
            return new Nail()
            {
                Id = validNail.Id,
                Name = validNail.Name,
                Length = validNail.Length,
                Material = validNail.Material,
                Count = validNail.Count,
                MinCount = validNail.MinCount,
                Price = validNail.Price,
            };
        }
    }
}
