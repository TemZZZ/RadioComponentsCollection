using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Сервисный класс со вспомогательными функциями для работы с
    /// радиокомпонентами
    /// </summary>
    public static class RadiocomponentService
    {
        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// физические величины и единицы измерения
        /// </summary>
        private static readonly
            Dictionary<RadiocomponentType,
                (RadiocomponentQuantity Quantity, RadiocomponentUnit Unit)>
            _radiocomponentTypeToPropertiesMap
                = new Dictionary<RadiocomponentType,
                    (RadiocomponentQuantity, RadiocomponentUnit)>
                {
                    [RadiocomponentType.Resistor]
                        = (RadiocomponentQuantity.Resistance,
                            RadiocomponentUnit.Ohm),
                    [RadiocomponentType.Inductor]
                        = (RadiocomponentQuantity.Inductance,
                            RadiocomponentUnit.Henry),
                    [RadiocomponentType.Capacitor]
                        = (RadiocomponentQuantity.Capacitance,
                            RadiocomponentUnit.Farad)
                };

        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// строковые представления
        /// </summary>
        private static readonly Dictionary<RadiocomponentType, string>
            _radiocomponentTypeToStringMap
                = new Dictionary<RadiocomponentType, string>
                {
                    [RadiocomponentType.Resistor] = "Резистор",
                    [RadiocomponentType.Inductor] = "Катушка индуктивности",
                    [RadiocomponentType.Capacitor] = "Конденсатор"
                };

        /// <summary>
        /// Словарь, ставящий в соответствие физическим величинам
        /// радиокомпонентов их строковые представления
        /// </summary>
        private static readonly Dictionary<RadiocomponentQuantity, string>
            _radiocomponentQuantityToStringMap
                = new Dictionary<RadiocomponentQuantity, string>
                {
                    [RadiocomponentQuantity.Resistance] = "Сопротивление",
                    [RadiocomponentQuantity.Inductance] = "Индуктивность",
                    [RadiocomponentQuantity.Capacitance] = "Емкость"
                };

        /// <summary>
        /// Словарь, ставящий в соответствие единицам измерений
        /// радиокомпонентов их строковые представления
        /// </summary>
        private static readonly Dictionary<RadiocomponentUnit, string>
            _radiocomponentUnitToStringMap
                = new Dictionary<RadiocomponentUnit, string>
                {
                    [RadiocomponentUnit.Ohm] = "Ом",
                    [RadiocomponentUnit.Henry] = "Гн",
                    [RadiocomponentUnit.Farad] = "Ф"
                };

        /// <summary>
        /// Возвращает соответствующую типу радиокомпонента физическую
        /// величину
        /// </summary>
        /// <param name="type">Тип радиокомпонента</param>
        /// <returns>Физическая величина радиокомпонента</returns>
        public static RadiocomponentQuantity GetRadiocomponentQuantity(
            RadiocomponentType type)
        {
            return _radiocomponentTypeToPropertiesMap[type].Quantity;
        }

        /// <summary>
        /// Возвращает соответствующую типу радиокомпонента единицу измерения
        /// </summary>
        /// <param name="type">Тип радиокомпонента</param>
        /// <returns>Единица измерения физической величины
        /// радиокомпонента</returns>
        public static RadiocomponentUnit GetRadiocomponentUnit(
            RadiocomponentType type)
        {
            return _radiocomponentTypeToPropertiesMap[type].Unit;
        }

        /// <summary>
        /// Преобразует строку в поле перечислимого типа
        /// <see cref="RadiocomponentType"/>.
        /// </summary>
        /// <param name="radiocomponentTypeAsString">Исходная строка</param>
        /// <returns>Поле перечислимого типа <see cref="RadiocomponentType"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static RadiocomponentType GetRadiocomponentTypeByString(
            string radiocomponentTypeAsString)
        {
            foreach (var radiocomponentTypeToString
                in _radiocomponentTypeToStringMap)
            {
                if (radiocomponentTypeToString.Value
                    == radiocomponentTypeAsString)
                {
                    return radiocomponentTypeToString.Key;
                }
            }

            throw new ArgumentException(
                $"Can't convert {radiocomponentTypeAsString} to " +
                $"{nameof(RadiocomponentType)} type.",
                nameof(radiocomponentTypeAsString));
        }

        /// <summary>
        /// Проверяет именованый параметр вещественного типа на
        /// принадлежность диапазону допустимых значений
        /// </summary>
        /// <param name="parameter">Параметр</param>
        /// <param name="parameterName">Имя параметра</param>
        /// <exception cref="ArgumentException">Если значение параметра NaN
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Если значение
        /// параметра меньше нуля или больше максимально допустимого double
        /// </exception>
        public static void ValidatePositiveDouble(double parameter,
            string parameterName = null)
        {
            if (parameterName is null)
            {
                parameterName = nameof(parameter);
            }

            if (double.IsNaN(parameter))
            {
                string valueIsNaNText
                    = $"Value of {parameterName} can't be NaN.";
                throw new ArgumentException(parameterName, valueIsNaNText);
            }

            if (double.IsPositiveInfinity(parameter))
            {
                string tooBigValueText
                    = $"Value of {parameterName} must be equal to or less " +
                      $"than {double.MaxValue}.";
                throw new ArgumentOutOfRangeException(parameterName,
                    tooBigValueText);
            }

            if (parameter < 0)
            {
                string lessThanZeroText
                    = $"Value of {parameterName} must be equal to or more " +
                      "than zero.";
                throw new ArgumentOutOfRangeException(parameterName,
                    lessThanZeroText);
            }
        }

        /// <summary>
        /// Формирует и возвращает строковое представление радиокомпонента по
        /// его типу и значению физической величины
        /// </summary>
        /// <param name="radiocomponentType">Типа радтокомпонента</param>
        /// <param name="radiocomponentValue">Значение физической величины
        /// радиокомпонента</param>
        /// <returns>Строковое представление радиокомпонента</returns>
        public static string ToString(RadiocomponentType radiocomponentType,
            double radiocomponentValue)
        {
            string typeAsString
                = _radiocomponentTypeToStringMap[radiocomponentType];

            var (quantity, unit)
                = _radiocomponentTypeToPropertiesMap[radiocomponentType];
            string quantityAsString
                = _radiocomponentQuantityToStringMap[quantity];
            string unitAsString = _radiocomponentUnitToStringMap[unit];

            return $"{typeAsString}; {quantityAsString} " +
                   $"{radiocomponentValue} {unitAsString}";
        }
    }
}
