using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Dnc.WPF.Converters
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class CNYConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cny = (decimal)value;

            return $"￥{cny.ToString("#.00")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0m;

            if (decimal.TryParse(value.ToString(), out var cny))
                return cny;

            return 0m;
        }
    }
}
