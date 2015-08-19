using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace LoggingTimesGUI
{
    public class ListStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = value as IEnumerable<string>;
            if (enumerable != null)
            {
                return enumerable.Aggregate("", (current, item) => current + (item + '\n'));
            }
            throw new ArgumentException("Not a list of strings");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var content = value as String;
            if (content != null)
            {
                return content.Split('\n').ToList();
            }
            throw new ArgumentException("Not a string so can't convert");
        }
    }
}