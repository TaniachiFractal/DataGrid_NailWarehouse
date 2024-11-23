namespace NailWarehouse.Web.Models
{
    /// <summary>
    /// Модель страницы ошибки
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Данные ошибки
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Показать данные ошибки
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
