using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MVVM
{
    public class BoolToVisibilityConverter : IValueConverter
    {
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
