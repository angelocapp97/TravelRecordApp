using System;
using System.Globalization;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTimeOffset)value;
            var rightNow = DateTimeOffset.Now;
            var difference = rightNow - dateTime;

            if (difference.TotalDays > 20)
                return $"{dateTime:d}";

            if (difference.TotalDays > 1)
                return $"{difference.TotalDays} days ago";

            if (difference.TotalHours > 1)
                return $"{difference.TotalHours:0} hours ago";

            if (difference.TotalMinutes > 1)
                return $"{difference.TotalMinutes:0} minutes ago";

            return $"{difference.TotalSeconds:0} seconds ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
