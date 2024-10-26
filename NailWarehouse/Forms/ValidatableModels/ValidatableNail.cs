using System;
using System.ComponentModel.DataAnnotations;
using NailWarehouse.Models;

namespace NailWarehouse.ValidatableModels
{
    /// <summary>
    /// Класс объекта гвоздя, который можно валидировать
    /// </summary>
    public class ValidatableNail
    {
        /// <summary>
        /// Идентификатор гвоздя
        /// </summary>     
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        [Required(ErrorMessage = "Введите название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название - строка от 3 до 50 символов")]
        public string Name { get; set; }

        /// <summary>
        /// Длина в миллиметрах
        /// </summary>
        [Range(0, 100000000)]
        public decimal Length { get; set; }

        /// <inheritdoc cref="Models.Material"/>
        [Range(0, 100000000)]
        public Material Material { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        [Range(0, 100000000)]
        public decimal Count { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [Range(0, 100000000)]
        public decimal MinCount { get; set; }

        /// <summary>
        /// Цена без НДС
        /// </summary>
        [Range(0, 100000000)]
        public decimal Price { get; set; }

    }
}
