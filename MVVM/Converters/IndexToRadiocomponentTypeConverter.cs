using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Model;

namespace MVVM.Converters
{
    /// <summary>
    /// Класс конвертера индекса в тип радиокомпонента из коллекции типов
    /// радиокомпонентов.
    /// </summary>
    public class IndexToRadiocomponentTypeConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует неотрицательное целое число в тип радиокомпонента из
        /// коллекции типов радиокомпонентов, если это число есть индекс типа
        /// радиокомпонента в коллекции, и возвращает тип радиокомпонента.
        /// </summary>
        /// <param name="value">Объект, представляеющий неотрицательное целое
        /// число</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Объект, представляющий коллекцию типов
        /// радиокомпонентов.</param>
        /// <param name="culture"></param>
        /// <returns>Тип радиокомпонента.</returns>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var index = (uint)value;
            var radiocomponentTypes = (List<RadiocomponentType_>)parameter;
            return GetRadiocomponentTypeByIndex(index, radiocomponentTypes);
        }

        /// <summary>
        /// Конвертирует тип радиокомпонента в неотрицательное целое число,
        /// соответствующее индексу типа радиокомпонента в коллекции типов
        /// радиокомпонентов, и возвращает это число.
        /// </summary>
        /// <param name="value">Объект, представляющий тип радиокомпонента.
        /// </param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Объект, представляющий коллекцию типов
        /// радиокомпонентов.</param>
        /// <param name="culture"></param>
        /// <returns>Неотрицательное целое число.</returns>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var radiocomponentType = (RadiocomponentType_)value;
            var radiocomponentTypes = (List<RadiocomponentType_>)parameter;
            return GetIndexOfRadiocomponentType(radiocomponentType,
                radiocomponentTypes);
        }

        #region -- Public static methods --

        /// <summary>
        /// Возвращает тип радиокомпонента из коллекции типов
        /// радиокомпонентов по индексу.
        /// </summary>
        /// <param name="index">Индекс типа радиокомпонента в коллекции.
        /// </param>
        /// <param name="radiocomponentTypes">Коллекция типов
        /// радиокомпонентов.</param>
        /// <returns>Тип радиокомпонента.</returns>
        public static RadiocomponentType_ GetRadiocomponentTypeByIndex(
            uint index, List<RadiocomponentType_> radiocomponentTypes)
        {
            return radiocomponentTypes[(int)index];
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
            RadiocomponentType_ radiocomponentType,
            List<RadiocomponentType_> radiocomponentTypes)
        {
            var index = radiocomponentTypes.IndexOf(radiocomponentType);
            return (index < 0) ? null : (uint?)index;
        }

        #endregion
    }
}
