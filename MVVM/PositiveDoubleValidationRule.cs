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
        /// <summary>
        /// Проверяет успешность преобразования строкового представления
        /// числа в неотрицательное вещественное число с плавающей точкой
        /// двойной точности и возвращает результат проверки.
        /// </summary>
        /// <param name="value">Исходное значение. Перед проверкой приводится
        /// к типу string.</param>
        /// <param name="cultureInfo">Информация о культуре, используемая в
        /// правиле валидации.</param>
        /// <returns>Результат проверки в виде экземпляра класса
        /// <see cref="ValidationResult"/>.</returns>
        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            var isToNotNegativeDoubleConvertedOk
                = TryConvertToNotNegativeDouble((string)value, out _);
            
            if (isToNotNegativeDoubleConvertedOk)
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
