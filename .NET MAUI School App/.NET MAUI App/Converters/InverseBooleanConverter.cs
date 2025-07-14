using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Barham_C971.Converters;

public class  InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool booleanValue)
        {
            return !booleanValue;
        }
        return value; // Return the original value if it's not a boolean
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool booleanValue)
        {
            return !booleanValue;
        }
        return value; // Return the original value if it's not a boolean
    }
}