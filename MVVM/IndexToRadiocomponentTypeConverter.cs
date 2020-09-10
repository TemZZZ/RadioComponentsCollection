using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс конвертера индекса в тип радиокомпонента из коллекции типов
    /// радиокомпонентов.
    /// </summary>
    public class IndexToRadiocomponentTypeConverter : IValueConverter
    {
        /// <inheritdoc cref="GetRadiocomponentTypeByIndex"/>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var index = (uint)value;
            var radiocomponentTypes = (IEnumerable<RadiocomponentType>)parameter;

            return GetRadiocomponentTypeByIndex(index, radiocomponentTypes);
        }

        /// <inheritdoc cref="GetIndexOfRadiocomponentType"/>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var radiocomponentType = (RadiocomponentType)value;
            var radiocomponentTypes = (IEnumerable<RadiocomponentType>)parameter;

            return GetIndexOfRadiocomponentType(radiocomponentType,
                radiocomponentTypes);
        }

        /// <summary>
        /// Возвращает тип радиокомпонента из коллекции типов
        /// радиокомпонентов по индексу.
        /// </summary>
        /// <param name="index">Индекс типа радиокомпонента в коллекции.
        /// </param>
        /// <param name="radiocomponentTypes">Коллекция типов
        /// радиокомпонентов.</param>
        /// <returns>Тип радиокомпонента.</returns>
        public static RadiocomponentType GetRadiocomponentTypeByIndex(
            uint index, IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            return radiocomponentTypes.ElementAt((int)index);
        }

        /// <summary>
        /// Возвращает индекс типа радиокомпонента в коллекции типов
        /// радиокомпонентов. Если такого типа в коллекции нет, возвращается
        /// null.
        /// </summary>
        /// <param name="radiocomponentType">Искомый тип радиокомпонента.
        /// </param>
        /// <param name="radiocomponentTypes">Коллекция типов
        /// радиокомпонентов.</param>
        /// <returns>Индекс искомого типа радиокомпонента или null.</returns>
        public static uint? GetIndexOfRadiocomponentType(
            RadiocomponentType radiocomponentType,
            IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            var radiocomponentTypesList = radiocomponentTypes.ToList();
            var index = radiocomponentTypesList.IndexOf(radiocomponentType);
            return (index < 0) ? null : (uint?)index;
        }
    }
}
