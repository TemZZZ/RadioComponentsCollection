using System.Globalization;
using System.Windows.Controls;

namespace MVVM.ValidationRules
{
    /// <summary>
    /// Класс правила валидации, проверяющего, соответствует ли текст
    /// неотрицательному вещественному числу.
    /// </summary>
    public class NotNegativeDoubleValidationRule : ValidationRule
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
            var stringRepresentation = ValidationRuleService
                .GetValidatingValue(value) as string;

            var isToNotNegativeDoubleConvertedOk
                = TryConvertToNotNegativeDouble(stringRepresentation, out _);
            
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

        /// <summary>
        /// Проверяет строковое представление числа и обновляет значение
        /// исходного числа, если строковое представление является
        /// неотрицательным вещественным числом с плавающей точкой двойной
        /// точности.
        /// </summary>
        /// <param name="valueStringRepresentation">Строковое представление
        /// числа.</param>
        /// <param name="value">Обновляемое числовое значение.</param>
        /// <returns>true, если строковое представление числа есть
        /// неотрицательное вещественное число с плавающей точкой двойной
        /// точности, иначе - false.</returns>
        public static bool UpdateIfNotNegativeDouble(
            string valueStringRepresentation, ref double value)
        {
            var isNewValueValid = TryConvertToNotNegativeDouble(
                valueStringRepresentation, out var newValue);
            if (isNewValueValid)
            {
                value = newValue;
            }
            return isNewValueValid;
        }
    }
}
