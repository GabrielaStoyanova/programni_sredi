using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace UI.Extras
{
    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is a string and hide it if it's a password
            if (value is string password)
            {
                return IsPassword(parameter as string) ? "********" : password;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool IsPassword(string propertyName)
        {
            // Add logic here to determine if the property is a password
            return propertyName != null && propertyName.ToLower().Contains("password");
        }
    }
}
