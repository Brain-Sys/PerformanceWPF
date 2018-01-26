using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1.Converters
{
    public class QuantityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;

            if (v == 0)
            {
                return new SolidColorBrush(Colors.Transparent);
            }
            else if (v < 1000)
            {
                return Application.Current.Resources["low"];
            }
            else if (v >= 1000 && v <= 3000)
            {
                return Application.Current.Resources["medium"];
            }
            else
            {
                return Application.Current.Resources["high"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}