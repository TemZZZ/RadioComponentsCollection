using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс конвертера коллекции типов радиокомпонентов в ассоциативный
    /// массив, ставящий в соответствие строковому представлению типа
    /// радиокомпонента строковые представления его физической величины и
    /// единицы измерения.
    /// </summary>
    public class
        RadiocomponentTypesToTypeAsStringToQuantityUnitAsStringMapConverter
            : IValueConverter
    {
        /// <inheritdoc
        /// cref="GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap"/>
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

        /// <summary>
        /// Формирует и возвращает ассоциативный массив, ставящий в
        /// соответствие строковому представлению типа радиокомпонента
        /// строковые представления его физической величины и единицы
        /// измерения.
        /// </summary>
        /// <param name="radiocomponentTypes">Типы радиокомпонентов.</param>
        /// <returns>Ассоциативный массив, ставящий в соответствие строковому
        /// представлению типа радиокомпонента строковые представления его
        /// физической величины и единицы измерения.</returns>
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

    }
}
