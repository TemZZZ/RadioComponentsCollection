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
    }
}
