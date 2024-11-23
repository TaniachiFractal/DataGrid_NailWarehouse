using System.ComponentModel;
using System.Text;

namespace NailWarehouse.Web.Controllers.Helpers
{
    /// <summary>
    /// Помощники для различных классов
    /// </summary>
    public static class Helpers
    {
        /// Получить описание поля enum
        /// <see cref="https://blog.hildenco.com/2018/07/getting-enum-descriptions-using-c.html"/>
        /// </summary>
        public static string GetDescription(object enumValue)
        {

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString() ?? "");

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description ?? "";
        }

        /// <summary>
        /// Поменять запятую на точку в десятичных дробях
        /// </summary>
        public static string? ResetCultureForDecimalPoint(decimal? input)
        {
            if (input % 1 == 0)
            {
                return ((int?)input).ToString();
            }
            else
            {
                var output = new StringBuilder(input.ToString());
                for (var i = 0; i < output.Length; i++)
                {
                    if (output[i] == ',')
                    {
                        output[i] = '.';
                        break;
                    }
                }
                return output.ToString();
            }
        }
    }
}
