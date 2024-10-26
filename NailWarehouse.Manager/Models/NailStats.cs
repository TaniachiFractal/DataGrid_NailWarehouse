using NailWarehouse.Models.Interfaces;
namespace NailWarehouse.Manager
{
    /// <summary>
    /// Вычисляемые данные о списке <see cref="Nail"/>
    /// </summary>
    public class NailStats : INailStats
    {
        /// <inheritdoc/>
        public decimal FullCount { get; set; }

        /// <inheritdoc/>
        public decimal FullSummaryNoTax { get; set; }

        /// <inheritdoc/>
        public decimal FullSummaryWithTax { get; set; }
    }
}
