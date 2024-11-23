using NailWarehouse.Models;

namespace NailWarehouse.Web.Models
{
    /// <summary>
    /// Модель для главной страницы
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// Общее количество элементов в хранилище
        /// </summary>
        public decimal FullCount { get; set; }

        /// <summary>
        /// Общая сумма товаров без НДС
        /// </summary>
        public decimal FullSumNoTax { get; set; }

        /// <summary>
        /// Общая сумма товаров с НДС
        /// </summary>
        public decimal FullSumWTax { get; set; }

        /// <summary>
        /// Список гвоздей из хранилища
        /// </summary>
        public IReadOnlyCollection<Nail>? DataList { get; set; }
    }
}
