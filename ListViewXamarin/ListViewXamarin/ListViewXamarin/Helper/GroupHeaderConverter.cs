using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class GroupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.Yellow;
            var items = (value as GroupResult).Items.ToList<Contacts>().ToList();
            if (items[0].IsHeaderTapped)
                return Color.Green;
            else
                return Color.Yellow;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
