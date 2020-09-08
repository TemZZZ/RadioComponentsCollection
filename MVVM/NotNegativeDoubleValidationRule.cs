using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVM
{
    /// <summary>
    /// Класс правила валидации, проверяющего, соответствует ли текст
    /// неотрицательному вещественному числу.
    /// </summary>
    public class NotNegativeDoubleValidationRule : ValidationRule
    {
        /// <summary>
        /// Возвращает значение, подлежащее валидации. Возвращает исходный
        /// входной параметр, если он не является объектом типа
        /// <see cref="BindingExpression"/>, или вытаскивает значение
        /// привязанного свойства, если входной параметр является экземпляром
        /// типа <see cref="BindingExpression"/>.
        /// </summary>
        /// <param name="value">Исходное значение, подлежащее валидации.
        /// </param>
        /// <returns>Значение типа <see cref="object"/>, подлежащее
        /// валидации.</returns>
        public object GetValidatingValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (!(value is BindingExpression))
            {
                return value;
            }

            return GetBindingSourcePropertyValue((BindingExpression)value);
        }

        /// <summary>
        /// Вытаскивает значение привязанного свойства, указанного в
        /// экземпляре типа <see cref="BindingExpression"/>.
        /// </summary>
        /// <param name="bindingExpression">Объект, содержащий информацию о
        /// привязке.</param>
        /// <returns>Значение типа <see cref="object"/>, подлежащее
        /// валидации.</returns>
        public object GetBindingSourcePropertyValue(
            BindingExpression bindingExpression)
        {
            var bindingSource = bindingExpression.ResolvedSource;
            var bindingSourcePropertyName
                = bindingExpression.ResolvedSourcePropertyName;
            var bindingSourceProperty = bindingSource.GetType()
                .GetProperty(bindingSourcePropertyName);

            if (bindingSourceProperty == null)
            {
                return null;
            }

            return bindingSourceProperty.GetValue(bindingSource);
        }

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
            var stringRepresentation = GetValidatingValue(value) as string;

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
    }
}
