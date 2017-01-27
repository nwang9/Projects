using System;
using System.Windows.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters.Converters
{
    public class BoolToStartStopServiceButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "Start Service";
            else
                return "Stop Service";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == "Start Service")
                return true;
            else
                return false;
        }
    }
}
