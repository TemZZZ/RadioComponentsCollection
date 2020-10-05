using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Model;

namespace MVVM.Converters
{
    /// <summary>
    /// Класс конвертера коллекции типов радиокомпонентов в ассоциативную
    /// коллекцию, ставящую в соответствие строковому представлению типа
    /// радиокомпонента строковые представления его физической величины и
    /// единицы измерения.
    /// </summary>
    public class RadiocomponentTypesToStringsDictionaryConverter
        : IValueConverter
    {
        /// <summary>
        /// Конвертирует коллекцию типов радиокомпонентов в ассоциативную
        /// коллекцию, ставящую в соответствие строковому представлению типа
        /// радиокомпонента строковые представления его физической величины и
        /// единицы измерения, и возвращает эту ассоциативную коллекцию.
        /// </summary>
        /// <param name="value">Объект, представляющий коллекцию типов
        /// радиокомпонентов.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Ассоциативная коллекция, ставящая в соответствие
        /// строковому представлению типа радиокомпонента строковые
        /// представления его физической величины и единицы измерения.
        /// </returns>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                (List<RadiocomponentType>)value);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region -- Public static methods --

        /// <summary>
        /// Формирует и возвращает ассоциативную коллекцию, ставящую в
        /// соответствие строковому представлению типа радиокомпонента
        /// строковые представления его физической величины и единицы
        /// измерения.
        /// </summary>
        /// <param name="radiocomponentTypes">Типы радиокомпонентов.</param>
        /// <returns>Ассоциативная коллекция, ставящая в соответствие
        /// строковому представлению типа радиокомпонента строковые
        /// представления его физической величины и единицы измерения.
        /// </returns>
        public static List<(string, string)>
            GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            var typeAsStringToQuantityUnitAsStringMap
                = new List<(string, string)>();

            foreach (var radiocomponentType in radiocomponentTypes)
            {
                var radiocomponentTypeAsString = RadiocomponentService
                    .ToString(radiocomponentType);

                var radiocomponentQuantity = RadiocomponentService
                    .GetRadiocomponentQuantity(radiocomponentType);
                var radiocomponentQuantityAsString = RadiocomponentService
                    .ToString(radiocomponentQuantity);

                var radiocomponentUnit = RadiocomponentService
                    .GetRadiocomponentUnit(radiocomponentType);
                var radiocomponentUnitAsString = RadiocomponentService
                    .ToString(radiocomponentUnit);

                var quantityUnitAsString = radiocomponentQuantityAsString +
                                           ", " + radiocomponentUnitAsString;

                typeAsStringToQuantityUnitAsStringMap.Add(
                    (radiocomponentTypeAsString, quantityUnitAsString));
            }

            return typeAsStringToQuantityUnitAsStringMap;
        }

        #endregion
    }
}
