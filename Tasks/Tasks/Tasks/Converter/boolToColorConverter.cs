using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Tasks.Converter
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int boolValue = (int)value;
            if (boolValue==2)
                return Color.FromHex("009900");
            else if(boolValue==1)
                return Color.Yellow;
            else
                return Color.FromHex("FF3333");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
