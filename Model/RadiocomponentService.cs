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
            Dictionary<RadioComponentType,
                (RadiocomponentQuantity Quantity, RadiocomponentUnit Unit)>
            _radiocomponentTypeToPropertiesMap
                = new Dictionary<RadioComponentType,
                    (RadiocomponentQuantity, RadiocomponentUnit)>
                {
                    [RadioComponentType.Resistor]
                        = (RadiocomponentQuantity.Resistance,
                            RadiocomponentUnit.Ohm),
                    [RadioComponentType.Inductor]
                        = (RadiocomponentQuantity.Inductance,
                            RadiocomponentUnit.Henry),
                    [RadioComponentType.Capacitor]
                        = (RadiocomponentQuantity.Capacitance,
                            RadiocomponentUnit.Farad)
                };

        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// строковые представления
        /// </summary>
        private static readonly Dictionary<RadioComponentType, string>
            _radiocomponentTypeToStringMap
                = new Dictionary<RadioComponentType, string>
                {
                    [RadioComponentType.Resistor] = "Резистор",
                    [RadioComponentType.Inductor] = "Катушка индуктивности",
                    [RadioComponentType.Capacitor] = "Конденсатор"
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
            RadioComponentType type)
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
            RadioComponentType type)
        {
            return _radiocomponentTypeToPropertiesMap[type].Unit;
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
    }
}
