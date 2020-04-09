using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace CalculatorMVVM.VIewModel
{
    // ponieważ pola typu string z wodoku łączymy (Binding) z własnością typu dceimal?
    // koneczne jest stworzenie konwertera (dziedziczącego po IValueConverter)
    // który zawiera dwie metody Convert i ConvetBack
    class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            return (System.Convert.ToDecimal(value)).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString()=="") return null;
            if (decimal.TryParse(value.ToString(), out _))
            {
               return System.Convert.ToDecimal(value.ToString(), CultureInfo.CurrentCulture);
            }
            return null;
        }
    }
}
