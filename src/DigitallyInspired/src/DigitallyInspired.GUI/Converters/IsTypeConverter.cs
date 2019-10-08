﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DigitallyInspired.GUI.Converters
{
    public class IsTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }

            return value.GetType() == (Type)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }
    }
}