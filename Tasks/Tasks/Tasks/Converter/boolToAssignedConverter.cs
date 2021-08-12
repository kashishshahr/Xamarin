using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Tasks.Converter
{
    public class boolToAssignedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int boolValue = (int)value;
            
            string assigned = "Assigned";
            string notassigned = "Not Assigned";
            if (boolValue==0)
                return notassigned;
            else
                return assigned;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
