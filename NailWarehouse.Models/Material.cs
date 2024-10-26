using System.ComponentModel;

namespace NailWarehouse.Models
{
    /// <summary>
    /// Варианты материалов <see cref="Nail"/>
    /// </summary>
    public enum Material
    {
        /// <summary>
        /// Медь
        /// </summary>
        [Description("Медь")]
        Copper = 1,

        /// <summary>
        /// Сталь
        /// </summary>
        [Description("Сталь")]
        Steel = 2,

        /// <summary>
        /// Железо
        /// </summary>
        [Description("Железо")]
        Iron = 3,

        /// <summary>
        /// Хром
        /// </summary>
        [Description("Хром")]
        Chrome = 4,
    }
}
