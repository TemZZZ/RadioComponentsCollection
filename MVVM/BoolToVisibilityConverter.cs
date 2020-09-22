using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MVVM
{
    /// <summary>
    /// Класс конвертера булева значения в видимость элемента XAML разметки.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует булево значение в видимсть элемента XAML разметки и
        /// возвращает эту видимость.
        /// </summary>
        /// <param name="value">Объект, представляющий булево значение.
        /// </param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Видимость элемента XAML разметки.</returns>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var isVisible = (bool)value;
            if (isVisible)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Конвертирует видимость элемента XAML разметки в булево значение и
        /// возвращает это булево значение.
        /// </summary>
        /// <param name="value">Объект, представляющий элемент XAML разметки.
        /// </param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Булево значение.</returns>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;
            switch (visibility)
            {
                case Visibility.Visible:
                    return true;
                default:
                    return false;
            }
        }
    }
}
