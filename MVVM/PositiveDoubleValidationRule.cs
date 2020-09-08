using System;
using System.Globalization;
using System.Windows.Controls;

namespace MVVM
{
    /// <summary>
    /// Класс правила валидации, проверяющего, соответствует ли текст
    /// положительному вещественному числу.
    /// </summary>
    public class PositiveDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            var isDoubleParsedOk = double.TryParse(
                (string)value, NumberStyles.Any,
                CultureInfo.InvariantCulture, out var doubleValue);

            if (!isDoubleParsedOk)
            {
                return new ValidationResult(false,
                    "String does not present a double value.");
            }

            if (doubleValue >= 0)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false,
                "String does not present a positive double value or zero.");
        }

        /// <summary>
        /// Преобразует строковое представление числа в неотрицательное
        /// вещественное число с плавающей точкой двойной точности.
        /// Возвращаемое значение показывает успешность преобразования.
        /// </summary>
        /// <param name="stringRepresentation">Строковое представление числа.
        /// </param>
        /// <param name="outputNotNegativeDoubleValue">Преобразованное
        /// вещественное число. В случае неудачного преобразования становится
        /// равным нулю.</param>
        /// <returns>true, если преобразование завершилось удачно,
        /// иначе - false.</returns>
        public static bool TryConvertToNotNegativeDouble(
            string stringRepresentation,
            out double outputNotNegativeDoubleValue)
        {
            if (stringRepresentation == null)
            {
                throw new ArgumentNullException(
                    nameof(stringRepresentation));
            }

            var isDoubleParsedOk = double.TryParse(stringRepresentation,
                NumberStyles.Any, CultureInfo.InvariantCulture,
                out var doubleValue);

            if (isDoubleParsedOk && doubleValue >= 0)
            {
                outputNotNegativeDoubleValue = doubleValue;
                return true;
            }

            const double defaultDoubleValue = 0;
            outputNotNegativeDoubleValue = defaultDoubleValue;
            return false;
        }
    }
}
