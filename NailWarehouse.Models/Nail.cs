using System;

namespace NailWarehouse.Models
{
    /// <summary>
    /// Класс объекта гвоздя
    /// </summary>
    public class Nail
    {
        /// <summary>
        /// Идентификатор гвоздя
        /// </summary>     
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Длина в миллиметрах
        /// </summary>
        public decimal Length { get; set; }

        /// <inheritdoc cref="Models.Material"/>
        public Material Material { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        public decimal MinCount { get; set; }

        /// <summary>
        /// Цена без НДС
        /// </summary>
        public decimal Price { get; set; }

    }
}
