using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Сервисный класс со вспомогательными функциями для работы с
    /// радиокомпонентами.
    /// </summary>
    public static class RadiocomponentService
    {
        #region -- Private fields --

        /// <summary>
        /// Словарь, ставящий в соответствие типу радиокомпонента
        /// инкапсулированный тип данных, физическую величину, единицу
        /// измерения.
        /// </summary>
        private static readonly Dictionary<RadiocomponentType,
            (Type EncapsulatedType, RadiocomponentQuantity Quantity,
            RadiocomponentUnit Unit)> _radiocomponentTypesInfoDictionary
            = new Dictionary<RadiocomponentType, (Type,
            RadiocomponentQuantity, RadiocomponentUnit)>
        {
            [RadiocomponentType.Resistor] = (typeof(Resistor),
                RadiocomponentQuantity.Resistance, RadiocomponentUnit.Ohm),
            [RadiocomponentType.Inductor] = (typeof(Inductor),
                RadiocomponentQuantity.Inductance, RadiocomponentUnit.Henry),
            [RadiocomponentType.Capacitor] = (typeof(Capacitor),
                RadiocomponentQuantity.Capacitance, RadiocomponentUnit.Farad)
        };

        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// строковые представления.
        /// </summary>
        private static readonly Dictionary<RadiocomponentType, string>
            _radiocomponentTypeToStringDictionary
                = new Dictionary<RadiocomponentType, string>
                {
                    [RadiocomponentType.Resistor] = "Резистор",
                    [RadiocomponentType.Inductor] = "Катушка индуктивности",
                    [RadiocomponentType.Capacitor] = "Конденсатор"
                };

        /// <summary>
        /// Словарь, ставящий в соответствие физическим величинам
        /// радиокомпонентов их строковые представления.
        /// </summary>
        private static readonly Dictionary<RadiocomponentQuantity, string>
            _radiocomponentQuantityToStringDictionary
                = new Dictionary<RadiocomponentQuantity, string>
                {
                    [RadiocomponentQuantity.Resistance] = "Сопротивление",
                    [RadiocomponentQuantity.Inductance] = "Индуктивность",
                    [RadiocomponentQuantity.Capacitance] = "Емкость"
                };

        /// <summary>
        /// Словарь, ставящий в соответствие единицам измерений
        /// радиокомпонентов их строковые представления.
        /// </summary>
        private static readonly Dictionary<RadiocomponentUnit, string>
            _radiocomponentUnitToStringDictionary
                = new Dictionary<RadiocomponentUnit, string>
                {
                    [RadiocomponentUnit.Ohm] = "Ом",
                    [RadiocomponentUnit.Henry] = "Гн",
                    [RadiocomponentUnit.Farad] = "Ф"
                };

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Список пар "тип радиокомпонента-множитель". Используется для
        /// генерации случайных радиокомпонентов.
        /// </summary>
        public static List<(RadiocomponentType, double)>
            RadiocomponentTypeToMultiplierTuplesForRandom
            => new List<(RadiocomponentType, double)>
            {
                (RadiocomponentType.Resistor, 1e-6),
                (RadiocomponentType.Inductor, 1e-12),
                (RadiocomponentType.Capacitor, 1e-15)
            };

        #endregion

        #region -- Public methods --

        /// <summary>
        /// Возвращает тип <see cref="RadiocomponentType"/> переданного
        /// радиокомпонента.
        /// </summary>
        /// <param name="radiocomponent">Радиокомпонент.</param>
        /// <returns>Тип радиокомпонента.</returns>
        public static RadiocomponentType GetRadiocomponentType(
            IRadiocomponent radiocomponent)
        {
            var encapsulatedType = radiocomponent.GetType();
            foreach (var item in _radiocomponentTypesInfoDictionary)
            {
                if (item.Value.EncapsulatedType == encapsulatedType)
                {
                    return item.Key;
                }
            }

            throw new ArgumentException(
                $"There is no {typeof(RadiocomponentType)} field for " +
                $"{encapsulatedType.Name}.");
        }

        /// <summary>
        /// Возвращает доступные типы радиокомпонентов.
        /// </summary>
        /// <returns>Список доступных типов радиокомпонентов.</returns>
        public static List<RadiocomponentType>
            GetAvailableRadiocomponentTypes()
        {
            return _radiocomponentTypesInfoDictionary.Keys.ToList();
        }

        /// <summary>
        /// Возвращает инкапсулированный перечислимым типом
        /// <see cref="RadiocomponentType"/> тип объекта-радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentType">Тип радиокомпонента.</param>
        /// <returns>Инкапсулированный тип объекта-радиокомпонента.</returns>
        public static Type GetEncapsulatedType(
            RadiocomponentType radiocomponentType)
        {
            return _radiocomponentTypesInfoDictionary[radiocomponentType]
                .EncapsulatedType;
        }

        /// <summary>
        /// Возвращает соответствующую типу радиокомпонента физическую
        /// величину.
        /// </summary>
        /// <param name="radiocomponentType">Тип радиокомпонента.</param>
        /// <returns>Физическая величина радиокомпонента.</returns>
        public static RadiocomponentQuantity GetRadiocomponentQuantity(
            RadiocomponentType radiocomponentType)
        {
            return _radiocomponentTypesInfoDictionary[radiocomponentType]
                .Quantity;
        }

        /// <summary>
        /// Возвращает соответствующую типу радиокомпонента единицу
        /// измерения.
        /// </summary>
        /// <param name="radiocomponentType">Тип радиокомпонента.</param>
        /// <returns>Единица измерения физической величины
        /// радиокомпонента.</returns>
        public static RadiocomponentUnit GetRadiocomponentUnit(
            RadiocomponentType radiocomponentType)
        {
            return _radiocomponentTypesInfoDictionary[radiocomponentType]
                .Unit;
        }

        /// <summary>
        /// Преобразует строку в поле перечислимого типа
        /// <see cref="RadiocomponentType"/>.
        /// </summary>
        /// <param name="radiocomponentTypeAsString">Исходная строка.</param>
        /// <returns>Поле перечислимого типа
        /// <see cref="RadiocomponentType"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static RadiocomponentType ToRadiocomponentType(
            this string radiocomponentTypeAsString)
        {
            foreach (var radiocomponentTypeToString
                in _radiocomponentTypeToStringDictionary)
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
        /// принадлежность диапазону допустимых значений.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <param name="parameterName">Имя параметра.</param>
        /// <exception cref="ArgumentException">Если значение параметра NaN.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Если значение
        /// параметра меньше нуля или больше максимально допустимого double.
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
        /// его типу и значению физической величины.
        /// </summary>
        /// <param name="radiocomponentType">Типа радтокомпонента.</param>
        /// <param name="radiocomponentValue">Значение физической величины
        /// радиокомпонента.</param>
        /// <returns>Строковое представление радиокомпонента.</returns>
        public static string ToString(RadiocomponentType radiocomponentType,
            double radiocomponentValue)
        {
            var typeAsString = _radiocomponentTypeToStringDictionary[
                radiocomponentType];

            var quantity = _radiocomponentTypesInfoDictionary[
                radiocomponentType].Quantity;
            var unit = _radiocomponentTypesInfoDictionary[
                radiocomponentType].Unit;

            var quantityAsString = _radiocomponentQuantityToStringDictionary[
                quantity];
            var unitAsString = _radiocomponentUnitToStringDictionary[unit];

            return $"{typeAsString}; {quantityAsString} " +
                   $"{radiocomponentValue} {unitAsString}";
        }

        /// <summary>
        /// Возвращает строковое представление типа радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentType">Тип радиокомпонента.</param>
        /// <returns>Строковое представление типа радиокомпонента.</returns>
        public static string ToString(RadiocomponentType radiocomponentType)
        {
            return _radiocomponentTypeToStringDictionary[radiocomponentType];
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
            return _radiocomponentUnitToStringDictionary[radiocomponentUnit];
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
            return _radiocomponentQuantityToStringDictionary[
                radiocomponentQuantity];
        }

        #endregion
    }
}
