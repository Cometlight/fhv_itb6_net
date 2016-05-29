using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Service;

namespace ManagerApplication.Converter
{
    public class CategoryIdToNameConverter : IValueConverter
    {
        // This does not look to nice, because we access the database all the time. A caching mechanism would be good
        // for improved performance. This cache could be included here, or better, in the CrudService class or even down in the broker.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? id = value as int?;
            if (!id.HasValue)
                return null;

            return new CrudService<Domain.ProductCategory>().Get(id).Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Problem: What if two categories have the same name.
            throw new InvalidOperationException("Cannot convert from string to category's ID");
        }
    }
}
