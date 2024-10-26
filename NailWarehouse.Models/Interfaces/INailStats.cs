namespace NailWarehouse.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для вычисляемых данных о списке <see cref="Nail"/>
    /// </summary>
    public interface INailStats
    {
        /// <summary>
        /// Общее к-во позиций на складе
        /// </summary>
        decimal FullCount { get; }

        /// <summary>
        /// Общая стоимость всех позиций без НДС
        /// </summary>
        decimal FullSummaryNoTax { get; }

        /// <summary>
        /// Общая стоимость всех позиций с НДС
        /// </summary>
        decimal FullSummaryWithTax { get; }
    }
}
