using NailWarehouse.Models;
using NailWarehouse.Web.Models;

namespace NailWarehouse.Web.Controllers.Helpers
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
                Length = ((decimal?)validNail.Length) ?? 0.0M,
                Material = validNail.Material,
                Count = ((decimal?)validNail.Count) ?? 0.0M,
                MinCount = ((decimal?)validNail.MinCount) ?? 0.0M,
                Price = ((decimal?)validNail.Price) ?? 0.0M,
            };
        }
    }
}
