using System;
using System.Collections.Generic;

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
            Dictionary<RadiocomponentType_,
                (RadiocomponentQuantity Quantity, RadiocomponentUnit Unit)>
            _radiocomponentTypeToPropertiesMap
                = new Dictionary<RadiocomponentType_,
                    (RadiocomponentQuantity, RadiocomponentUnit)>
                {
                    [RadiocomponentType_.Resistor]
                        = (RadiocomponentQuantity.Resistance,
                            RadiocomponentUnit.Ohm),
                    [RadiocomponentType_.Inductor]
                        = (RadiocomponentQuantity.Inductance,
                            RadiocomponentUnit.Henry),
                    [RadiocomponentType_.Capacitor]
                        = (RadiocomponentQuantity.Capacitance,
                            RadiocomponentUnit.Farad)
                };

        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// строковые представления
        /// </summary>
        private static readonly Dictionary<RadiocomponentType_, string>
            _radiocomponentTypeToStringMap
                = new Dictionary<RadiocomponentType_, string>
                {
                    [RadiocomponentType_.Resistor] = "Резистор",
                    [RadiocomponentType_.Inductor] = "Катушка индуктивности",
                    [RadiocomponentType_.Capacitor] = "Конденсатор"
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
            RadiocomponentType_ type)
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
            RadiocomponentType_ type)
        {
            return _radiocomponentTypeToPropertiesMap[type].Unit;
        }

        /// <summary>
        /// Преобразует строку в поле перечислимого типа
        /// <see cref="RadiocomponentType_"/>.
        /// </summary>
        /// <param name="radiocomponentTypeAsString">Исходная строка</param>
        /// <returns>Поле перечислимого типа <see cref="RadiocomponentType_"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static RadiocomponentType_ ToRadiocomponentType(
            this string radiocomponentTypeAsString)
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
                $"{nameof(RadiocomponentType_)} type.",
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
        public static string ToString(RadiocomponentType_ radiocomponentType,
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

        /// <summary>
        /// Возвращает строковое представление типа радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentType">Тип радиокомпонента.</param>
        /// <returns>Строковое представление типа радиокомпонента.</returns>
        public static string ToString(RadiocomponentType_ radiocomponentType)
        {
            return _radiocomponentTypeToStringMap[radiocomponentType];
        }

        /// <summary>
        /// Возвращает строковое представление единицы измерения физизической
        /// величины радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentUnit">Единица измерения физической
        /// величины радиокомпонента.</param>
        /// <returns>Строковое представление единицы измерения физизической
        /// величины радиокомпонента.</returns>
        public static string ToString(RadiocomponentUnit radiocomponentUnit)
        {
            return _radiocomponentUnitToStringMap[radiocomponentUnit];
        }

        /// <summary>
        /// Возвращает строковое представление физической величины
        /// радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentQuantity">Физическая величина
        /// радиокомпонента.</param>
        /// <returns>Строковое представление физической величины
        /// радиокомпонента.</returns>
        public static string ToString(
            RadiocomponentQuantity radiocomponentQuantity)
        {
            return _radiocomponentQuantityToStringMap[
                radiocomponentQuantity];
        }
    }
}
